using Dto.Test.Question;
using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Test;

public class TestViewModel : BaseDto
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    public List<QuestionViewModel> QuestionViewModel { get; set; }
}