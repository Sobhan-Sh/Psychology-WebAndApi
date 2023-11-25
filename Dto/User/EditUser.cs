using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Dto.User.Gender;
using Utility.Dto;
using Utility.ReturnError;

namespace Dto.User;

public class EditUser : BaseDto
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string FName { get; set; }

    [Display(Name = "فامیلی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string LName { get; set; }

    [Display(Name = "تلفن همراه")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Phone { get; set; }

    [Display(Name = "ادرس")]
    public string? Address { get; set; }

    //[Display(Name = "رمزعبور")]
    //[Required(ErrorMessage = ErrorHandling.Required)]
    //[DataType(DataType.Password)]
    public string? Password { get; set; }

    //[Display(Name = "تکرار رمز عبور")]
    //[Required(ErrorMessage = ErrorHandling.Required)]
    //[DataType(DataType.Password)]
    //[Compare("Password")]
    //public string? ConfirmPassword { get; set; }

    [Display(Name = "وضعیت تلفن همراه")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public bool MobailActiveStatus { get; set; }

    public string? ActivationCode { get; set; }

    [Display(Name = "اواتار")]
    public IFormFile? ImageUser { get; set; }

    public string? Avatar { get; set; }

    [Display(Name = "جنسیت")]
    public int GenderId { get; set; }

    public int RoleID { get; set; }

    public string? Token { get; set; }
}