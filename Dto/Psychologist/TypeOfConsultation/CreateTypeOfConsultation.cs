using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Psychologist.TypeOfConsultation;

public class CreateTypeOfConsultation : BaseDto
{
    [Display(Name = "نوع جلسه روانشناسی")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [Range(100000, int.MaxValue, ErrorMessage = ErrorHandling.Range)]
    public int Price { get; set; }
}