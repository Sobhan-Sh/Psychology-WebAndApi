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

    public void Edit(string title, string text)
    {
        Title = title;
        Text = text;
        UpdatedAt = DateTime.Now;
        IsActive = false;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Active()
    {
        IsActive = true;
    }

    public void DeActive()
    {
        IsActive = false;
    }

    public void Resotr()
    {
        IsDeleted = false;
    }
}