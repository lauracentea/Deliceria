using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Deliceria.Data.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}

public class LoginDto
{
    [Required]
    public  string Email {  get; set; }
    [Required]
    [MinLength(8)]
    public  string Password { get; set; }
}

public class RegisterDto
{
    [Required]
    public  string Email { get; set; }
    [Required]
    [MinLength(8)]
    public  string Password { get; set; }
    [Required]
    public  string FirstName { get; set; }
    [Required]
    public  string LastName { get; set; }
}