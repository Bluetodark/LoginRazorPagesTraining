using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginRazorPagesTraining.ViewModels.Requests;

namespace LoginRazorPagesTraining.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration Registration { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Domain.UserManager userManager = new Domain.UserManager();

            if (userManager.RegisterUser(Registration.UserName, Registration.ConfirmPassword)) {
                Console.WriteLine("Registration successful! You can now log in."); 
            } else {
                Console.WriteLine("Username already taken. Please try again with a different username."); 
            }

            return RedirectToPage("Index");
        }
    }
}
