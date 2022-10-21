using Identity.Core.DTOs;
using Identity.Core.IServices;
using Identity.Shared.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> GetUsers(UserRequest userRequest)
        {
            var userDTOs = await _userService.GetUsersAsync(userRequest);
            return userDTOs == null ? NotFound() : Ok(userDTOs);
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var userDTO = await _userService.GetUserByIdAsync(id);
            return userDTO == null ? NotFound() : Ok(userDTO);
        }

        [Route("{id}/avatar")]
        [HttpGet]
        public async Task<IActionResult> GetUserAvatar(string id)
        {
            var avatarDTO = await _userService.GetUserAvatarAsync(id);
            return avatarDTO == null ? NotFound() : Ok(avatarDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromForm] UserFormDTO userForUpdatingDTO)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userForUpdatingDTO);
            return updatedUser != null ? Ok(updatedUser) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var userId = await _userService.DeleteUserAsync(id);
            return userId != null ? Ok(userId) : NotFound();
        }

        //[HttpPut(Name = "UserAvatar")]
        //public async Task<IActionResult> GetUsersAvatar()
        //{
        //    return Ok(await _userService.GetUserIdWithAvatar());
        //}
    }
}