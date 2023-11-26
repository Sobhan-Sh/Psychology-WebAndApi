using Dto.Role;
using Dto.User.Gender;
using System.ComponentModel.DataAnnotations;
using Dto.Psychologist;
using Utility.Dto;

namespace Dto.User;

public class UserViewModel : BaseDto
{
    [Display(Name = "نام")]
    public string FName { get; set; }

    [Display(Name = "فامیلی")]
    public string LName { get; set; }

    [Display(Name = "شماره همراه")]
    public string Phone { get; set; }

    [Display(Name = "ادرس")]
    public string? Address { get; set; }

    [Display(Name = "رمز عبور")]
    public string Password { get; set; }

    [Display(Name = "حالت وضعیت موبایل")]
    public bool MobailActiveStatus { get; set; }

    public string ActivationCode { get; set; }

    [Display(Name = "اواتار")]
    public string? Avatar { get; set; }

    public RoleViewModel? RoleViewModel { get; set; }

    public GenderViewModel? GenderViewModel { get; set; }

    public List<PsychologistViewModel> PsychologistViewModels { get; set; }
}