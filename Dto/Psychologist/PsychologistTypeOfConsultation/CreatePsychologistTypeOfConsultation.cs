using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Psychologist.PsychologistTypeOfConsultation;

public class CreatePsychologistTypeOfConsultation : BaseDto
{
    [Display(Name = "کدام روانشناس")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int PsychologistId { get; set; }

    [Display(Name = "چه نوع جلسه ای")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int TypeOfConsultationId { get; set; }
}