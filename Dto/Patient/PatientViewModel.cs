using System.ComponentModel.DataAnnotations;
using PC.Dto.User;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Patient;

public class PatientViewModel : BaseDto
{
    [Display(Name = "کد ملی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string NationalCode { get; set; }

    [Display(Name = "سن")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int Age { get; set; }

    public int UserId { get; set; }

    public bool IsPatient { get; set; }

    public UserViewModel UserViewModel { get; set; }

    public int PatientExamId { get; set; }
}