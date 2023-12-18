using PC.Utility.Dto;

namespace PC.Dto.Test.Answer;

public class AnswerViewModel : BaseDto
{
    public string Title { get; set; }

    public int Score { get; set; }

    public string? Description { get; set; }

    public int QuestionId { get; set; }
}