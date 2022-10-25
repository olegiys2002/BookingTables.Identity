using Firebase.Auth;

namespace Identity.ServicesConfiguration
{
    public static class AuthorizationExtensions
    {
        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {

            });
        }
    }
}
