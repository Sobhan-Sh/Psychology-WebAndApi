using System.ComponentModel.DataAnnotations;
using Utility.Dto;
using Utility.ReturnError;

namespace Dto.Test.Answer;

public class CreateAnswer : BaseDto
{
    [Display(Name = "جواب")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    [Display(Name = "نمره")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public int Score { get; set; }

    [Display(Name = "توضیحات")]
    public string? Description { get; set; }

    public int QuestionId { get; set; }
}