using FluentValidation;
using FluentValidation.AspNetCore;
using Identity.Validation.User;

namespace Identity.ServicesConfiguration
{
    public static class FLuentValidationExtensions
    {
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UserFormValidator>();
            services.AddFluentValidationAutoValidation();
        }
    }
}
