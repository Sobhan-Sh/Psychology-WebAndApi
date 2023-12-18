using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Psychologist;

public class CreatePsychologist : BaseDto
{
    [Display(Name = "کد ملی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [RegularExpression(@"^\d{10,}$", ErrorMessage = "فیلد باید یک عدد با حداقل 10 رقم باشد.")]
    public string NationalCode { get; set; }

    [Display(Name = "کد پرونده طبابت")]
    public string? MedicalLicennseCode { get; set; }

    [Display(Name = "سن")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int Age { get; set; }

    [Display(Name = "تاریخ تولد")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "درصد همکاری")]
    public int? Commission { get; set; }

    [Display(Name = "عکس پروانه طبابت")]
    public IFormFile? ImageLicennse { get; set; }

    public string? EvidencePath { get; set; }

    public int UserId { get; set; }
}