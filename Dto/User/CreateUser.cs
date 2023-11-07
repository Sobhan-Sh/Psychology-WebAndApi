using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.User;

public class CreateUser : BaseDto
{
    [Required]
    public string FName { get; set; }

    [Required]
    public string LName { get; set; }

    [Required]
    public string Phone { get; set; }

    public string? Address { get; set; }

    [Required]
    public string Password { get; set; }

    public bool MobailActiveStatus { get; set; }

    [Required]
    public string ActivationCode { get; set; }

    public IFormFile? ImageUser { get; set; }

    public string? Avatar { get; set; }

    public int? RoleID { get; set; }

    public int? PatientId { get; set; }

    public string? Token { get; set; }

    public string FullName()
    {
        return FName + LName;
    }
}