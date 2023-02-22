using AutoMapper;
using Identity.Core.DTOs;
using Identity.Core.IServices;
using Identity.Models.Models;
using BookingTables.Shared;
using Nest;

namespace Identity.Core.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IMapper _mapper;
        private readonly ICacheService<List<User>> _cacheService;
        private readonly ICacheService<User> _cacheUserService;
        private readonly string _userKeyCaching = "userCache";
        private readonly IElasticClient _elasticClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
      
        public AuthenticationManager(IMapper mapper, ICacheService<User> cacheUserService, ICacheService<List<User>> cacheService, IElasticClient elasticClient, IUnitOfWork unitOfWork, IStorage storage)
        {
            _mapper = mapper;
            _cacheService = cacheService;
            _cacheUserService = cacheUserService;
            _elasticClient = elasticClient;
            _unitOfWork = unitOfWork;
            _storage = storage;
        }
        public async Task<UserDTO> RegisterUserAsync(UserFormDTO userForCreationDTO)
        {
            if (userForCreationDTO.AvatarFormDTO.Image == null)
            {
                return null;
            }
            var image = userForCreationDTO.AvatarFormDTO.Image;
            byte[] imageData;
            imageData = Image.ImageInBytes(image);

            var user = _mapper.Map<User>(userForCreationDTO);

            user.Avatar = new Avatar()
            {
                Image = imageData
            };

            await _storage.UploadAvatarAsync(userForCreationDTO.AvatarFormDTO.Image);
            var result = await _unitOfWork.UserRepository.CreateUserAsync(user,userForCreationDTO.Password);
              
            if (result.Succeeded)
            {
                if (userForCreationDTO.Role == "Admin")
                {
                    await _unitOfWork.UserRepository.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await _unitOfWork.UserRepository.AddToRoleAsync(user, "User");
                }

                await _elasticClient.IndexDocumentAsync(user);

                var userDTO = _mapper.Map<UserDTO>(user);

                await _cacheUserService.CacheItems(user.Id, user);
                await _cacheService.RemoveCache(_userKeyCaching);

                return userDTO;
            }

            else
            {
                return null;
            }
           
        }

    }
}
