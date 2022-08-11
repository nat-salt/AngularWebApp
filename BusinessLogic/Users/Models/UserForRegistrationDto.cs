using System.ComponentModel.DataAnnotations;

namespace AngularWebApp.BusinessLogic.Users.Models;

public class UserForRegistrationDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is Required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is Required")]
    public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}
