using PC.Utility.Dto;

namespace PC.Dto.Psychologist.Comment;

public class CreateComment : BaseDto
{
    public string? Text { get; set; }

    public string? ObjPath { get; set; }

    public int? PaitentId { get; set; }

    public int PsychologistId { get; set; }

    public int? UserId { get; set; }

    public int Sender { get; set; }

    public bool IsVisit { get; set; }
}