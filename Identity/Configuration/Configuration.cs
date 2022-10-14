using IdentityServer4.Models;

namespace Identity.Configuration
{
    public static class Configurations
    {

        public static IEnumerable<IdentityResource> GetIdentityResources =>
         new List<IdentityResource>
         {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile()
         };
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "tablesClient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = {"tablesAPI"},
                AllowOfflineAccess = true 
            }
        };
        public static IEnumerable<ApiScope> ApiScopes =>
         new ApiScope[]
         {
             new ApiScope("tablesAPI")
         };

        public static IEnumerable<ApiResource> ApiResources =>
         new ApiResource[]
         {
             new ApiResource
             {
                Name = "tablesAPI",
                Scopes =
                {
                     "tablesAPI"
                },
                //ApiSecrets=
                // {
                //     new Secret("table_secret".Sha256()),
                // }
                
             }

         };
    }
}
