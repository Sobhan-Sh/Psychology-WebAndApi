using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;

namespace PD.Entity.Psychologist;

public class PsychologistTypeOfConsultation : BaseEntity
{
    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist Psychologist { get; set; }

    public int TypeOfConsultationId { get; set; }
    [ForeignKey("TypeOfConsultationId")]
    public TypeOfConsultation TypeOfConsultation { get; set; }

    public void Edit(int psychologistId, int typeOfConsultationId)
    {
        PsychologistId = psychologistId;
        TypeOfConsultationId = typeOfConsultationId;
        UpdatedAt = DateTime.Now;
    }
}