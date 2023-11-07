using System.ComponentModel.DataAnnotations;
using Utility.ReturnError;

namespace Dto.account;

public class Login
{
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string CellPhone { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Password { get; set; }

    public bool RemomberMe { get; set; }
}