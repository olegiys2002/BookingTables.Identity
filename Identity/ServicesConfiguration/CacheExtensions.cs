using Identity.Core.IServices;
using Identity.Core.Services;
using Identity.Models.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.ServicesConfiguration
{
    public static class CacheExtensions
    {
        public static void ConfigureCaching(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            var redisConfig = configuration.GetSection("redis").Value;
            services.AddDistributedRedisCache(
                options =>
                {
                    options.Configuration = redisConfig;
                });
            services.AddSingleton<ICacheService<List<User>>, CacheService<List<User>>>();
            services.AddSingleton<ICacheService<User>, CacheService<User>>();
          
        }
    }
}
