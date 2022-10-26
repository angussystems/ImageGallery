using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MRI.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            //for role bases Authorization
            new IdentityResource("roles",
                "Your role(s)",
                new []{ "role"}),
            //for attribute based Authorization
            new IdentityResource("country","The country you are living in",new List<string>(){ "country"})
           
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("imagegalleryapi", "Image Gallery API",new []{ "role","country"})
            {
                Scopes={ "imagegalleryapi.fullaccess" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("imagegalleryapi.fullaccess")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientName = "Image Gallery",
                ClientId="imagegalleryclient",
                AllowedGrantTypes = GrantTypes.Code,
                //refresh token when user is not login to IDP
               // AllowOfflineAccess=true,
                //set identity and access token expiration
                //AccessTokenLifetime
                //IdentityTokenLifetime
                RedirectUris=
                {
                    "https://localhost:7000/signin-oidc"
                },
                PostLogoutRedirectUris=
                {
                    "https://localhost:7000/signout-callback-oidc"
                },
                AllowedScopes=
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    "imagegalleryapi.fullaccess",
                    "country"
                },
                ClientSecrets=
                {
                    new Secret("secret" .Sha256())
                },
                RequireConsent=true,
                
            }
        };
}