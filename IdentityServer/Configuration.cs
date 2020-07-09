using System;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> {
                //new ApiResource("ApiOne"),
                //new ApiResource("ApiTwo", new string[] { "rc.api.garndma" }),
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client> {

                new Client {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                   

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = { "ApiOne" }
                },

                new Client {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                    RedirectUris = { "https://localhost:5001/signin-oidc" },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //"rc.scope",
                    },
                            AllowAccessTokensViaBrowser = true

                },
                new Client {
                    ClientId = "client_id_mvc2",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //"rc.scope",
                    },
                            AllowAccessTokensViaBrowser = true

                } 

            };
    }
}
