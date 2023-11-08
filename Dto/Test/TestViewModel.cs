using Dto.Test.Question;
using Utility.Dto;

namespace Dto.Test;

public class TestViewModel : BaseDto
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public List<QuestionViewModel> QuestionViewModel { get; set; }

    public int Price { get; set; }
}