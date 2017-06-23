using IdentityModel;
using IdentityServer4.Models;
using Newtonsoft.Json;
using Calemas.Erp.Sso.Api.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;

namespace Calemas.Erp.Sso.Api
{
    public class Config
    {
        public static User MakeUsersAdmin()
        {
            return new User
            {
                SubjectId = "1",
                Username = "admin",
                Password = "admin",
                Claims = ClaimsForAdmin("Administrador", "admin@email.com.br")
            };
        }

        public static List<Claim> ClaimsForAdmin(string name, string email)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, name),
                new Claim(JwtClaimTypes.Email, email),
                new Claim("role", "admin"),
            };
        }

        public static List<Claim> ClaimsForColaborador(string colaboradorId, string name, string email)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, colaboradorId),
                new Claim(JwtClaimTypes.Name, name),
                new Claim(JwtClaimTypes.Email, email),
                new Claim("role", "colaborador"),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ssocalemas", "SPA Client Implicit")
                {
                    Scopes = new List<Scope>()
                    {
                        new Scope
                        {
                            UserClaims = new List<string> {"name", "openid", "email", "role"},
                            Name = "calemas",
                            Description = "SPA Client Implicit",
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
                    ClientId = "ssocalemas",
                    ClientName = "SPA Client Implicit",
                    ClientSecrets = { new Secret("segredo".Sha256()) },
                    
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = {
                        "http://localhost:8080/#/authorized/?"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:8080/#/loggedout/?"
                    },

                    AllowedCorsOrigins = { "http://localhost:8080" },

                    AllowedScopes = { "openid", "profile", "email", "calemas" }
                },

            };
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                MakeUsersAdmin()
            };
        }

    }
}