using PC.Utility.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD.Entity.Psychologist;

public class PsychologistAboutUs : BaseEntity
{
    public string Title { get; set; }

    public string TextAbout { get; set; }

    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist Psychologist { get; set; }

    public void Edit(string title, string textAbout)
    {
        Title = title;
        TextAbout = textAbout;
        UpdatedAt = DateTime.Now;
    }
}