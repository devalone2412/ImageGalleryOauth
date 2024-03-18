using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Marvin.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new("roles", "Your role(s)", new[] { JwtClaimTypes.Role })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new()
            {
                ClientName = "Image Gallery",
                ClientId = "imagegalleryclient",
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:7184/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:7184/signout-callback-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles"
                },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                RequireConsent = true
            }
        };
}