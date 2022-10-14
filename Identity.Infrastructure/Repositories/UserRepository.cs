using Identity.Infrastructure.IRepositories;
using Identity.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
            
        }

        //public Task<User> GetUserAsync(Guid id)
        //{
        //    return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //}

        public Task<Avatar> GetUserAvatarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetValidUserAsync(string email, string passwordHash)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == passwordHash);
        }
    }
}
