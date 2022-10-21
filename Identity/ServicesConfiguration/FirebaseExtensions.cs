using Identity.Core.ExternalModels.OptionsModels;
using Identity.Core.IServices;
using Identity.Core.Services;

namespace Identity.ServicesConfiguration
{
    public static class FirebaseExtensions
    {
        public static void ConfigureStorage(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<FireStorageOptions>(configuration.GetSection(FireStorageOptions.FireStorageSettings));
            services.AddSingleton<IStorage, FireStorage>();
        }
    }
}
