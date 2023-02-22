namespace Identity.Core.DTOs
{
    public class UserDTO : EntityDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
