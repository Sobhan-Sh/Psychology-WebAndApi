﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.User;

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
    [RegularExpression(@"^\d{11,}$", ErrorMessage = "فیلد باید یک عدد با حداقل 11 رقم باشد.")]
    [DataType(dataType: DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Display(Name = "ادرس")]
    public string? Address { get; set; }

    public string? Password { get; set; }

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