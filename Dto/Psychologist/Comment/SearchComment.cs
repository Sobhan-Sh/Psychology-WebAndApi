namespace PC.Dto.Psychologist.Comment;

public class SearchComment
{
    public int? PaitentId { get; set; }

    public int? PsychologistId { get; set; }

    public int? UserId { get; set; }

    public bool IsVisit { get; set; }
}