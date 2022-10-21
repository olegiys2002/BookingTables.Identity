using Identity.Core.IServices;
using Identity.Infrastructure;
using Identity.Infrastructure.IRepositories;
using Identity.Infrastructure.Repositories;
using Identity.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private IUserRepository? _userRepository;

        public UnitOfWork(ApplicationContext applicationContext,UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        public async Task SaveChangesAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_applicationContext,_userManager);
                return _userRepository;
            }
        }
    }
}
