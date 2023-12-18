using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Test.Question;

public class CreateQuestion : BaseDto
{
    [Display(Name = "متن سوال")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    public int TestId { get; set; }
}