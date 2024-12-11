using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginRazorPagesTraining.ViewModels.Requests;
using Infrastructure;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoginRazorPagesTraining.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly UserManager _userManager;

        [BindProperty]
        public UserRegistration Registration { get; set; }

        public RegisterModel(ILogger<RegisterModel> logger, UserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_userManager.CreateUser(Registration.UserName, Registration.ConfirmPassword))
            {
                Console.WriteLine("Registration successful! You can now log in.");
            }
            else
            {
                Console.WriteLine("Username already taken. Please try again with a different username.");
            }

            return RedirectToPage("Index");
        }
    }
}
