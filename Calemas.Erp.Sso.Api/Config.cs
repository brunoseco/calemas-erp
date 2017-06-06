using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

namespace Calemas.Erp.Sso.Api
{
    public class Config
    {
        public static TestUser MakeUsersAdmin()
        {
            var tools = new List<dynamic>
            {
                new { Name = "Bancos", Value = "/banco" },
                new { Name = "Campanhas", Value = "/campanha" },
                new { Name = "Mídias", Value = "/midia" },
            };

            var _toolsForAdmin = JsonConvert.SerializeObject(tools);

            return new TestUser
            {
                SubjectId = "32",
                Username = "teste@cna.com.br",
                Password = "123456",
                Claims = new[]
                {
                    new Claim(JwtClaimTypes.Name, "Usuário CNA"),
                    new Claim(JwtClaimTypes.Email, "teste@cna.com.br"),
                    new Claim("tools", _toolsForAdmin),
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apipdf", "Portal do Franqueador Api")
                {
                    Scopes = new List<Scope>()
                    {
                        new Scope
                        {
                            UserClaims = new List<string> {"name", "email", "role", "tools"},
                            Name = "apipdf",
                            Description = "sso basic",
                        }
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ssopdf",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "apipdf"
                    },
                    AlwaysIncludeUserClaimsInIdToken = false
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                MakeUsersAdmin()
            };
        }        

    }
}