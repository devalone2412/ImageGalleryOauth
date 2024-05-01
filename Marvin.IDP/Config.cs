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
            new("roles", "Your role(s)", new[] { JwtClaimTypes.Role }),
            new IdentityResource("country", "The country you're living in", new[] { "country" }),
        };

    public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
    {
        new("imagegalleryapi", "Image Gallery API", new[] { "role", "country" })
        {
            Scopes = { "imagegalleryapi.fullaccess", "imagegalleryapi.read", "imagegalleryapi.write" },
            ApiSecrets = {new Secret("apisecret".Sha256())}
        }
    };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new("imagegalleryapi.fullaccess"),
            new("imagegalleryapi.read"),
            new("imagegalleryapi.write"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new()
            {
                ClientName = "Image Gallery",
                ClientId = "imagegalleryclient",
                AllowedGrantTypes = GrantTypes.Code,
                AccessTokenType = AccessTokenType.Reference,
                AccessTokenLifetime = 120,
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowOfflineAccess = true,
                // AuthorizationCodeLifetime = ...
                // IdentityTokenLifetime = ...
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
                    "roles",
                    // "imagegalleryapi.fullaccess",
                    "imagegalleryapi.read",
                    "imagegalleryapi.write",
                    "country"
                },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                // RequireConsent = true
            },
            new()
            {
                ClientName = "Image Gallery BFF",
                ClientId = "imagegallerybff",
                AllowedGrantTypes = GrantTypes.Code,
                AccessTokenType = AccessTokenType.Reference,
                AccessTokenLifetime = 120,
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowOfflineAccess = true,
                // AuthorizationCodeLifetime = ...
                // IdentityTokenLifetime = ...
                RedirectUris =
                {
                    "https://localhost:7119/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:7119/signout-callback-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles",
                    // "imagegalleryapi.fullaccess",
                    "imagegalleryapi.read",
                    "imagegalleryapi.write",
                    "country"
                },
                ClientSecrets =
                {
                    new Secret("anothersecret".Sha256())
                },
                // RequireConsent = true
            }
        };
}