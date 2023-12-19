using System.ComponentModel.DataAnnotations;
using PC.Utility.ReturnError;

namespace PC.Dto.User;

public class ChangePassword
{
    public int Id { get; set; }

    [Display(Name = "رمز فعلی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [DataType(DataType.Password)]
    [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = ErrorHandling.StringLength)]
    public string Password { get; set; }

    [Display(Name = "رمز جدید")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [DataType(DataType.Password)]
    [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = ErrorHandling.StringLength)]
    public string NewPassword { get; set; }

    [Display(Name = "تکرار رمز جدید")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = ErrorHandling.PasswordConfirm)]
    [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = ErrorHandling.StringLength)]
    public string ConfirmNewPassword { get; set; }
}