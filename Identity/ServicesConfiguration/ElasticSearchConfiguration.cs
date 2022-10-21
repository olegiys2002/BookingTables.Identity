using Identity.Models.Models;
using Nest;

namespace Identity.ServicesConfiguration
{
    public static class ElasticSearchConfiguration
    {
        public static void ConfigureElasticsearch(
          this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:uri"];
            var defaultIndex = configuration["ELKConfiguration:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(defaultIndex);
            settings.EnableApiVersioningHeader();

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<User>(user => user
                    .Ignore(p => p.Id)
                    .Ignore(p => p.Avatar)
                    .Ignore(p => p.AvatarId)
                    .Ignore(p => p.Email)
                    .Ignore(p => p.PasswordHash)
                );
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<User>(x => x.AutoMap())
            );
        }
    }
}
