using LoginRazorPagesTraining.ViewModels.Requests;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Diagnostics.Eventing.Reader;
using Infrastructure;
using Domain;

namespace LoginRazorPagesTraining.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public UserLogin Login { get; set; }

        public void OnGet()
        {
            // Directly instantiate MyDbContext without DbContextOptions
            var dbContext = new MyDbContext();

            // Create UserRepository and UserManager
            var userRepository = new UserRepository(dbContext);
            var userManager = new UserManager(userRepository);

            // Fetch users
            userManager.GetUsers();
        }

        public IActionResult OnPost()
        {
            //write username/password to console for debugging
            Console.WriteLine(Login.UserName);
            Console.WriteLine(Login.Password);

            var dbContext = new MyDbContext();
            var userRepository = new UserRepository(dbContext);

            Domain.Interfaces.IUserManager userManager = new Domain.UserManager(userRepository);

            if (userManager.ValidateUser(Login.UserName, Login.Password)) {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("ID", 1.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return new RedirectToPageResult("Success");
            } else {
                return new RedirectToPageResult("Failed");
            }

            //Hack hardcoded authentication
            //List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim("ID", 1.ToString()));

            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            //return new RedirectToPageResult("Success");
        }
    }
}
