namespace Identity.Infrastructure.IRepositories
{
    public interface IRepositoryBase<T,K>
    {
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        Task<List<T>> FindAllAsync(bool trackChanges,K requestFeatures);
    }
}
