using PC.Utility.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD.Entity.Patient;

public class Comment : BaseEntity
{
    public string? Text { get; set; }

    public int? PaitentId { get; set; }
    [ForeignKey("PaitentId")]
    public Patient? Patient { get; set; }

    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist.Psychologist Psychologist { get; set; }

    public int? UserId { get; set; }
    [ForeignKey("UserId")]
    public User.User? AdUser { get; set; }

    public string? ObjPath { get; set; }
}