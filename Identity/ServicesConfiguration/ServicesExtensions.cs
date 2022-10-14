using Identity.Core.IServices;
using Identity.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.ServicesConfiguration
{
    public static class ServicesExtensions
    {
        public static void ConfigureApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddRouting(opt => opt.LowercaseUrls = true);
        }
    }
}
