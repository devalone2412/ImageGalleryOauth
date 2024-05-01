using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ImageGallery.BFF.Controllers;

[Authorize]
public class UserSessionController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserSessionController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public IActionResult GivenName()
    {
        var objectToReturn = new
        {
            given_name = User.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value
        };

        return Json(objectToReturn);
    }

    public async Task Logout()
    {
        var client = _httpClientFactory.CreateClient("IDPClient");
        
        var discoveryDocument = await client.GetDiscoveryDocumentAsync();
        if (discoveryDocument.IsError)
        {
            throw new Exception(discoveryDocument.Error);
        }

        var accessTokenRevocationResponse = await client.RevokeTokenAsync(new()
        {
            Address = discoveryDocument.RevocationEndpoint,
            ClientId = "imagegallerybff",
            ClientSecret = "anothersecret",
            Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)
        });
        if (accessTokenRevocationResponse.IsError)
        {
            throw new Exception(accessTokenRevocationResponse.Error);
        }
        
        var refreshTokenRevocationResponse = await client.RevokeTokenAsync(new()
        {
            Address = discoveryDocument.RevocationEndpoint,
            ClientId = "imagegallerybff",
            ClientSecret = "anothersecret",
            Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken)
        });
        if (refreshTokenRevocationResponse.IsError)
        {
            throw new Exception(refreshTokenRevocationResponse.Error);
        }
        
        await HttpContext.SignOutAsync("BFFCookieScheme");
        await HttpContext.SignOutAsync("BFFChallengeScheme");
    }
}