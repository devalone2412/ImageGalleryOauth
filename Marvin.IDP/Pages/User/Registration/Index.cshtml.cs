using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using IdentityModel;
using Marvin.IDP.Entities;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marvin.IDP.Pages.User.Registration;

[AllowAnonymous]
[SecurityHeaders]
public class Index : PageModel
{
    private readonly ILocalUserService _localUserService;
    private readonly IIdentityServerInteractionService _interaction;

    [BindProperty] public InputModel Input { get; set; }

    public Index(ILocalUserService localUserService, IIdentityServerInteractionService interaction)
    {
        _localUserService = localUserService ?? throw new ArgumentNullException(nameof(localUserService));
        _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
    }

    public IActionResult OnGet(string returnUrl)
    {
        BuildModel(returnUrl);
        return Page();
    }

    private void BuildModel(string returnUrl)
    {
        Input = new InputModel
        {
            ReturnUrl = returnUrl
        };
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            BuildModel(Input.ReturnUrl);
            return Page();
        }

        var userToCreate = new Entities.User
        {
            UserName = Input.UserName,
            Subject = Guid.NewGuid().ToString(),
            Email = Input.Email,
            Active = false
        };

        userToCreate.Claims.Add(new UserClaim
        {
            Type = "country",
            Value = Input.Country
        });

        userToCreate.Claims.Add(new UserClaim
        {
            Type = JwtClaimTypes.GivenName,
            Value = Input.GivenName
        });

        userToCreate.Claims.Add(new UserClaim
        {
            Type = JwtClaimTypes.FamilyName,
            Value = Input.FamilyName
        });

        _localUserService.AddUser(userToCreate, Input.Password);
        await _localUserService.SaveChangesAsync();

        var activationUrl = Url.PageLink("/User/Activation/Index",
            values: new { securityCode = userToCreate.SecurityCode });
        
        Console.WriteLine(activationUrl);
        return Redirect("~/User/ActivationCodeSent");

        // var isUser = new IdentityServerUser(userToCreate.Subject)
        // {
        //     DisplayName = userToCreate.UserName
        // };
        //
        // await HttpContext.SignInAsync(isUser);
        //
        // if (_interaction.IsValidReturnUrl(Input.ReturnUrl) || Url.IsLocalUrl(Input.ReturnUrl))
        // {
        //     return Redirect(Input.ReturnUrl);
        // }
        //
        // return Redirect("~/");
    }
}