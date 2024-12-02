using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginRazorPagesTraining.Pages
{

    [Authorize]
    public class SuccessModel : PageModel
    {
        public void OnGet()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
        }

        public async Task<IActionResult> OnPostLogoutAsync() { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index"); 
        }
    }
}
