using Identity.Infrastructure.IRepositories;
using Identity.Infrastructure.Views;
using Identity.Models.Models;
using BookingTables.Shared.RepositoriesExtensions;
using BookingTables.Shared.RequestModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, UserRequest>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public Task<User> GetUserAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }
        public override Task<List<User>> FindAllAsync(bool trackChanges, UserRequest requestFeatures)
        {
            return !trackChanges ? _userManager.Users.GetPage(requestFeatures.PageNumber, requestFeatures.PageSize).AsNoTracking().ToListAsync() :
                                   _userManager.Users.GetPage(requestFeatures.PageNumber, requestFeatures.PageSize).ToListAsync();
        }
        public Task<Avatar> GetUserAvatarAsync(string id)
        {
           return _userManager.Users.Include(user => user.Avatar).Where(user=>user.Id == id).Select(user => user.Avatar).FirstOrDefaultAsync();
        }
        public Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }
        public  Task<IdentityResult> AddToRoleAsync(User user,string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }
        public Task<IdentityResult> UpdateUserAsync(User user)
        {
            return _userManager.UpdateAsync(user);
        }
        public Task DeleteUserAsync(User user)
        {
            return _userManager.DeleteAsync(user);
        }

        public Task<List<UserAvatarsDTO>> GetAvatarsWihtUserName()
        {
            return _context.UserAvatars.ToListAsync();
        }

    }
}
