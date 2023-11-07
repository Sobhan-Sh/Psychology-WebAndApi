using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Test.Answer;

public class AnswerViewModel : BaseDto
{
    public string Title { get; set; }

    public int Score { get; set; }

    public string? Description { get; set; }

    public int QuestionId { get; set; }
}