using Dto.Test.Answer;
using Utility.Dto;

namespace Dto.Test.Question;

public class QuestionViewModel : BaseDto
{
    public string Title { get; set; }

    public int TestId { get; set; }

    public List<AnswerViewModel>? AnswerViewModels { get; set; }
}