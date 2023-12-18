using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.User;

public class CreateUser : BaseDto
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string FName { get; set; }

    [Display(Name = "فامیلی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string LName { get; set; }

    [Display(Name = "تلفن همراه")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [RegularExpression(@"^\d{11,}$", ErrorMessage = "فیلد باید یک عدد با حداقل 11 رقم باشد.")]
    [DataType(dataType: DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Display(Name = "ادرس")]
    public string? Address { get; set; }

    [Display(Name = "رمزعبور")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [DataType(DataType.Password)]
    [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = ErrorHandling.StringLength)]
    public string Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = ErrorHandling.PasswordConfirm)]
    [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = ErrorHandling.StringLength)]
    public string ConfirmPassword { get; set; }

    [Display(Name = "وضعیت تلفن همراه")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public bool MobailActiveStatus { get; set; }

    public string? ActivationCode { get; set; }

    [Display(Name = "اواتار")]
    public IFormFile? ImageUser { get; set; }

    public string? Avatar { get; set; }

    [Display(Name = "جنسیت")]
    public int GenderId { get; set; }

    public int? RoleID { get; set; }

    public int? PatientId { get; set; }

    public string? Token { get; set; }

    public string FullName()
    {
        return FName + LName;
    }
}