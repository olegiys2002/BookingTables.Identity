using AutoMapper;
using Identity.Core.DTOs;
using Identity.Core.IServices;
using Identity.Models.Models;
using Identity.Shared;
using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationManager(IUnitOfWork unitOfWork,IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
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

            var result = await _userManager.CreateAsync(user,userForCreationDTO.Password);
           
            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new Role
                {
                    Name = "User"
                });
                await _userManager.AddToRoleAsync(user,"User");
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

    }
}
