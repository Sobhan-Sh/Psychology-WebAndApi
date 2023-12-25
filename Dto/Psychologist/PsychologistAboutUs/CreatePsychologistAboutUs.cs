using PC.Utility.Dto;
using PC.Utility.ReturnError;
using System.ComponentModel.DataAnnotations;

namespace PC.Dto.Psychologist.PsychologistAboutUs;

public class CreatePsychologistAboutUs : BaseDto
{
    [Display(Name = "عنوانی در باره من")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    [Display(Name = "متنی در باره من")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string TextAbout { get; set; }

    public int? PsychologistId { get; set; }
}