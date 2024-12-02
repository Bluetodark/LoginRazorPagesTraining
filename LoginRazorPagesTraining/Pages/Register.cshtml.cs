using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginRazorPagesTraining.ViewModels.Requests;
using Infrastructure;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginRazorPagesTraining.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration Registration { get; set; }

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dbContext = new MyDbContext();
            var userRepository = new UserRepository(dbContext);

            Domain.UserManager userManager = new Domain.UserManager(userRepository);

            if (userManager.RegisterUser(Registration.UserName, Registration.ConfirmPassword)) {
                Console.WriteLine("Registration successful! You can now log in."); 
            } else {
                Console.WriteLine("Username already taken. Please try again with a different username."); 
            }

            return RedirectToPage("Index");
        }
    }
}
