using PC.Utility.Dto;

namespace PC.Dto.Psychologist.Article;

public class ArticleViewModel : BaseDto
{
    public int PsychologistId { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }
}