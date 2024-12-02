using System.ComponentModel.DataAnnotations;

namespace LoginRazorPagesTraining.ViewModels.Requests;
public class UserLogin
{
    [Required(ErrorMessage = "Your user name is required")]
    public string UserName { get; init; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your password is required")]
    public string Password { get; init; }
}