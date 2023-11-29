using System.ComponentModel.DataAnnotations;
using Utility.Dto;
using Utility.ReturnError;

namespace Dto.Psychologist.PsychologistWorkingDateAndTime;

public class CreatePsychologistWorkingDateAndTime : BaseDto
{
    public int PsychologistId { get; set; }

    [Display(Name = "چه روزی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int PsychologistWorkingDaysId { get; set; }

    [Display(Name = "چه ساعتی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int PsychologistWorkingHoursId { get; set; }
}