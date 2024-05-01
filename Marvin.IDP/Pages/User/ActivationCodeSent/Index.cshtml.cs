using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marvin.IDP.Pages.User.ActivationCodeSent;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    public void OnGet()
    {
        
    }
}