using PC.Utility.Dto;

namespace PC.Dto.Psychologist.Article;

public class CreateArticle : BaseDto
{
    public int PsychologistId { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }
}