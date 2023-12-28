using PC.Dto.Patient;
using PC.Dto.User;
using PC.Utility.Domain;

namespace PC.Dto.Psychologist.Comment;

public class CommentViewModel : BaseEntity
{
    public string? Text { get; set; }

    public string? ObjPath { get; set; }

    public PatientViewModel? PatientViewModel { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }

    public UserViewModel? UserViewModel { get; set; }

    public int Sender { get; set; }
}