using AutoMapper;
using Identity.Core.DTOs;
using Identity.Core.IServices;
using Identity.Infrastructure.Views;
using Identity.Models.Models;
using Microsoft.AspNetCore.Identity;
using Nest;
using BookingTables.Shared.RequestModels;
using BookingTables.Shared;

namespace Identity.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService<List<User>> _cacheService;
        private readonly ICacheService<User> _cacheUserService;
        private readonly IElasticClient _elasticClient;
        private readonly UserManager<User> _userManager;
        private readonly string _userKeyCaching = "userCache";
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService<User> cacheUserService, ICacheService<List<User>> cacheService, IElasticClient elasticClient,UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cacheUserService = cacheUserService;
            _cacheService = cacheService;
            _elasticClient = elasticClient;
            _userManager = userManager;
        }
        public async Task<string?> DeleteUserAsync(string id)
        {
            var user = await _unitOfWork.UserRepository.GetUserAsync(id);

            if (user == null)
            {
                return null;
            }
            await _unitOfWork.UserRepository.DeleteUserAsync(user);

            await _cacheUserService.RemoveCache(id);
            await _cacheService.RemoveCache(_userKeyCaching);
            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await _cacheUserService.TryGetCache(id);

            if (user == null)
            {
                user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return null;
                }

                await _cacheUserService.CacheItems(id, user);
            }
            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<List<UserDTO>> GetUsersAsync(UserRequest userRequest)
        {
         
            var users = await _cacheService.TryGetCache(_userKeyCaching);
            
            if (users == null)
            {
                users = await _unitOfWork.UserRepository.FindAllAsync(false, userRequest);
          
                var result = await _elasticClient.SearchAsync<User>(s => s.Query(
                     q => q.QueryString(
                     d => d.Query('*' + userRequest.SearchWord + '*')
                )));

                if (users.Count == 0)
                {
                    return null;
                }

                await _cacheService.CacheItems(_userKeyCaching, result.Documents.ToList());
            }
            var userDTOs = _mapper.Map<List<UserDTO>>(users);

            return userDTOs;
        }

        public async Task<AvatarDTO> GetUserAvatarAsync(string id)
        {
            var avatar = await _unitOfWork.UserRepository.GetUserAvatarAsync(id);

            if (avatar == null)
            {
                return null;
            }

            var avatarDTO = _mapper.Map<AvatarDTO>(avatar);
            return avatarDTO;
        }

        public async Task<List<UserAvatarsDTO>> GetUserIdWithAvatar()
        {
          var usersViewResult = await _unitOfWork.UserRepository.GetAvatarsWihtUserName();
          return usersViewResult;
        }
        public async Task<UserDTO> UpdateUserAsync(string id, UserFormDTO userForUpdatingDTO)
        {
            var user = await _unitOfWork.UserRepository.GetUserAsync(id);

            if (user == null)
            {
                return null;
            }

            byte[] imageData;
            var image = userForUpdatingDTO.AvatarFormDTO.Image;
            imageData = Image.ImageInBytes(image);

            user.Avatar = new Avatar()
            {
                Image = imageData
            };

            user.UserName = userForUpdatingDTO.UserName;
            user.Email = userForUpdatingDTO.Email;

            await _unitOfWork.UserRepository.UpdateUserAsync(user);
            
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
