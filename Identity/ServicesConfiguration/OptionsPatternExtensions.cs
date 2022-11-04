using Identity.Core.ExternalModels.OptionsModels;

namespace Identity.ServicesConfiguration
{
    public static class OptionsPatternExtensions
    {
        public static void ConfigureAppOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<FireStorageOptions>(configuration.GetSection(FireStorageOptions.FireStorageSettings));
            services.Configure<AzureStorageOptions>(configuration.GetSection(AzureStorageOptions.AzureStorageSettings));
        }
    }
}
