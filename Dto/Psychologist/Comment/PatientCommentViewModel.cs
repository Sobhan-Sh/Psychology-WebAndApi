namespace PC.Dto.Psychologist.Comment;

public class PatientCommentViewModel
{
    public int PatientId { get; set; }

    public int PsychologistId { get; set; }

    public List<CommentViewModel> CommentViewModels { get; set; }
}