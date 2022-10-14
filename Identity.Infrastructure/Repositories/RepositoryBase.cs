using Identity.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _context;
        protected DbSet<T> dataSet;
        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dataSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dataSet.Remove(entity);
        }

        public virtual Task<List<T>> FindAllAsync(bool trackChanges)
        {
            return !trackChanges ? dataSet.AsNoTracking().ToListAsync() : dataSet.ToListAsync();
        }

        public virtual void Update(T entity)
        {
            dataSet.Update(entity);
        }
    }
}
