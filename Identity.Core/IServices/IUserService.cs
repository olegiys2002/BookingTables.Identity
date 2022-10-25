using Identity.Core.DTOs;
using BookingTables.Shared.RequestModels;
using Identity.Infrastructure.Views;

namespace Identity.Core.IServices
{
    public interface IUserService
    {
        Task<string?> DeleteUserAsync(string id);
        Task<UserDTO> UpdateUserAsync(string id, UserFormDTO userForUpdatingDTO);
        Task<List<UserDTO>> GetUsersAsync(UserRequest userRequest);
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<AvatarDTO> GetUserAvatarAsync(string id);
        Task<List<UserAvatarsDTO>> GetUserIdWithAvatar();
    }
}
