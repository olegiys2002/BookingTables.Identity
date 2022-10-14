using Identity.Models.Models;

namespace Identity.Infrastructure.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        //Task<User> GetUserAsync(Guid id);
        Task<User> GetValidUserAsync(string email, string passwordHash);
        Task<Avatar> GetUserAvatarAsync(int id);
        //Task<List<UserAvatarsDTO>> GetAvatarsWihtUserId();
    }
}
