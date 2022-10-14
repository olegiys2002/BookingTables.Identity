using Identity.Core.Services;

namespace Identity.ServicesConfiguration
{
    public static class AutoMapperExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
