using Identity.Core.DTOs;
using Identity.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        
        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
           
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]UserFormDTO userFormDTO)
        {
            var userDTO = await _authenticationManager.RegisterUserAsync(userFormDTO);
            return userDTO == null ? BadRequest() : Ok(userDTO);
        }
       
    }
}
