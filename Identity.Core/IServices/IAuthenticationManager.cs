using Identity.Core.DTOs;
using Identity.Models.Models;

namespace Identity.Core.IServices
{
    public interface IAuthenticationManager
    {
        Task<UserDTO> RegisterUserAsync(UserFormDTO userForCreationDTO);
    }
}
