using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;

namespace PD.Entity.Test;

public class Answer : BaseEntity
{
    [Required]
    public string Title { get; set; }

    [Required]
    public int Score { get; set; }

    public string? Description { get; set; }

    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question Question { get; set; }
}