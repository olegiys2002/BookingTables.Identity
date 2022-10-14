namespace Identity.ServicesConfiguration
{
    public static class CORSConfigurationExtensions
    {
        public static void ConfigureCQRS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });

        }
    }
}
