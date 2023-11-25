using System.ComponentModel.DataAnnotations;
using Utility.Dto;
using Utility.ReturnError;

namespace Dto.Test.Question;

public class CreateQuestion : BaseDto
{
    [Display(Name = "متن سوال")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    public int TestId { get; set; }
}