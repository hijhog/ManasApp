using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ManasApp.Identity.Configurations
{
    public static class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "admin",
                    Password = "12345",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Main Admin"),
                        new Claim(JwtClaimTypes.GivenName, "Admin"),
                        new Claim(JwtClaimTypes.FamilyName, "Main"),
                        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                    }
                }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "web.client",
                    ClientName = "ManasApp Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("web_secret_key".Sha256()) },
                    AllowedScopes = { "myApi.read" },

                    AccessTokenLifetime = 60
                },

                new Client
                {
                    ClientId = "manasapp.client",
                    ClientName = "ManasApp Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("manasapp_secret_key".Sha256()) },
                    AllowedScopes = { "myApi.read" },

                    AccessTokenLifetime = 60,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly
                },
            };
    }
}
