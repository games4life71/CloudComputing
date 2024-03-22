using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;


public class RegistrationModel
{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? EmailAddress { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is required")]
    public string? PhoneNumber { get; set; }

    [PasswordPropertyText]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

}