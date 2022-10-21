namespace Identity.Core.IServices
{
    public interface ICacheService<T>
    {
        Task CacheItems(string key, T items);
        Task<T> TryGetCache(string key);
        Task RemoveCache(string key);
    }
}
