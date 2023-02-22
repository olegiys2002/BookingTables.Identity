using Microsoft.AspNetCore.Identity;

namespace Identity.Models.Models
{
    public class User : IdentityUser
    {
        public Avatar Avatar { get; set; }
        public int AvatarId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
