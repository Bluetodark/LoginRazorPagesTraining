using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain;

namespace LoginRazorPagesTraining.Pages
{

    [Authorize]
    public class SuccessModel : PageModel
    {
        private readonly ILogger<SuccessModel> _logger;
        private readonly UserManager _userManager;

        public SuccessModel(ILogger<SuccessModel> logger, UserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
            Users = _userManager.GetUsers();
        }

        public async Task<IActionResult> OnPostLogoutAsync() { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index"); 
        }
    }
}
