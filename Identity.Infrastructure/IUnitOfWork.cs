using Identity.Infrastructure.IRepositories;

namespace Identity.Core.IServices
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task SaveChangesAsync();
    }
}
