using Identity.Configuration;
using Identity.Infrastructure;
using Identity.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System.Net;

namespace Identity.ServicesConfiguration
{
    public static class IdentityServerConfiguration
    {
        public static void ConfigureIdentityServer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(options =>
                    {
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequiredLength = 2;
                        options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();

          
            services.AddIdentityServer()
                    .AddAspNetIdentity<User>()
                    .AddInMemoryClients(Configurations.Clients)
                    .AddInMemoryIdentityResources(Configurations.GetIdentityResources)
                    .AddInMemoryApiResources(Configurations.ApiResources)
                    .AddInMemoryApiScopes(Configurations.ApiScopes)   
                    .AddDeveloperSigningCredential();
        }
    }
}