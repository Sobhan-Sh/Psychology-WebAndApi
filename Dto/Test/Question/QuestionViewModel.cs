using PC.Dto.Test.Answer;
using PC.Utility.Dto;

namespace PC.Dto.Test.Question;

public class QuestionViewModel : BaseDto
{
    public string Title { get; set; }

    public int TestId { get; set; }

    public List<AnswerViewModel>? AnswerViewModels { get; set; }
}