using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Psychologist.PsychologistWorkingDateAndTime;

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