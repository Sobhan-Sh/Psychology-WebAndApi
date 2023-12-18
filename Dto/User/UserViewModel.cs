using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PC.Dto.Psychologist;
using PC.Dto.Role;
using PC.Dto.User.Gender;
using PC.Utility.Dto;

namespace PC.Dto.User;

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
    public IFormFile? ImageUser { get; set; }

    public string? Avatar { get; set; }

    public RoleViewModel? RoleViewModel { get; set; }

    [Display(Name = "جنسیت")]
    public GenderViewModel? GenderViewModel { get; set; }

    public List<PsychologistViewModel>? PsychologistViewModels { get; set; }

    public string FullName()
    {
        return this.FName + " " + this.LName;
    }
}