using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Test.Answer;

public class CreateAnswer : BaseDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public int Score { get; set; }

    public string? Description { get; set; }

    [Required]
    public int QuestionId { get; set; }
}