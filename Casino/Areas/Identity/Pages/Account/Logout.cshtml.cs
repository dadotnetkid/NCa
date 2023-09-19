using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Casino.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var returnUrl = Url.Content("~/");
            Redirect(returnUrl);
        }

        public void OnPost()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var returnUrl = Url.Content("~/");
            Redirect(returnUrl);
        }

    }
}
