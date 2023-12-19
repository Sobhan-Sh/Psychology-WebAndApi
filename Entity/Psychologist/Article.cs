using PC.Utility.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD.Entity.Psychologist;

public class Article : BaseEntity
{
    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist Psychologist { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }
}