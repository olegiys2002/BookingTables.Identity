namespace Identity.Core.DTOs
{
    public class UserFormDTO
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public AvatarFormDTO AvatarFormDTO { get; set; }
    }
}
