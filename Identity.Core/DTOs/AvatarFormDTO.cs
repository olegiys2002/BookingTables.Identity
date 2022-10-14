using Microsoft.AspNetCore.Http;

namespace Identity.Core.DTOs
{
    public class AvatarFormDTO
    {
        public IFormFile Image { get; set; }
    }
}
