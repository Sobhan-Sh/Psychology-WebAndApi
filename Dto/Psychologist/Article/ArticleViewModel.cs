namespace PC.Dto.Psychologist.Article;

public class ArticleViewModel
{
    public int PsychologistId { get; set; }

    public PsychologistViewModel Psychologist { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }
}