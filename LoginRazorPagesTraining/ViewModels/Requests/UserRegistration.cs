using System.ComponentModel.DataAnnotations;

namespace LoginRazorPagesTraining.ViewModels.Requests;
public class UserRegistration
{
    [Required(ErrorMessage = "Your user name is required")]
    public string UserName { get; init; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; }
    [Required(ErrorMessage = "Your password is required")]
    [DataType(DataType.Password)]
    public string Password { get; init; }
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; init; }
}

