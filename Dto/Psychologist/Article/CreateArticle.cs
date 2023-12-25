using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Psychologist.Article;

public class CreateArticle : BaseDto
{
    public int PsychologistId { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    [Display(Name = "متن")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Text { get; set; }
}