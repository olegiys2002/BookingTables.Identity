﻿using Identity.Core.IServices;
using Identity.Core.Services;


namespace Identity.ServicesConfiguration
{
    public static class ServicesExtensions
    {
        public static void ConfigureApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IUserService, UserService>();    
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddSingleton<IStorage, AzureStorage>();
        }
    }
}
