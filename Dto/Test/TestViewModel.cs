using PC.Dto.Test.Question;
using PC.Utility.Dto;

namespace PC.Dto.Test;

public class TestViewModel : BaseDto
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public List<QuestionViewModel> QuestionViewModel { get; set; }

    public int Price { get; set; }
}