using Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Identity.ServicesConfiguration
{
    public static class DatabaseExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services,IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString,
                                                      builder => builder.MigrationsAssembly("Identity")));
        }
    }
}
