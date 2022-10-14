using Identity.Core.IServices;
using Identity.Infrastructure;
using Identity.Infrastructure.IRepositories;
using Identity.Infrastructure.Repositories;

namespace Identity.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private IUserRepository? _userRepository;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task SaveChangesAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_applicationContext);
                return _userRepository;
            }
        }
    }
}
