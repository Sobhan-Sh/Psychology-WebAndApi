using PC.Dto.Patient;
using PC.Dto.Psychologist;
using PC.Dto.User;
using PC.Utility.Domain;

namespace PC.Dto.Psychologist.Comment;

public class CommentViewModel : BaseEntity
{
    public string? Text { get; set; }

    public string? ObjPath { get; set; }

    public PatientViewModel? Patient { get; set; }

    public PsychologistViewModel Psychologist { get; set; }

    public UserViewModel? AdUser { get; set; }
}