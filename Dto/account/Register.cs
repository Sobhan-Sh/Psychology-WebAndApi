using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PC.Dto.account;

public class Register
{

    [Required]
    public string FName { get; set; }

    [Required]
    public string LName { get; set; }

    [Required]
    public string Password { get; set; }

    //[]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Phone { get; set; }

    public string? ActivationCode { get; set; }

    public IFormFile? ImageUser { get; set; }

    public string? Avatar { get; set; }

    public bool MobailActiveStatus { get; set; }

    public int? RoleID { get; set; }

    public string? Token { get; set; }

    public string FullName()
    {
        return FName + LName;
    }
}