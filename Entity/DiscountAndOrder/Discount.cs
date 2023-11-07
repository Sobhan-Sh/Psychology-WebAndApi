using System.ComponentModel.DataAnnotations.Schema;
using Utility.Domain;

namespace Entity.DiscountAndOrder;

public class Discount : BaseEntity
{
    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient.Patient Patient { get; set; }

    public int PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist.Psychologist Psychologist { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}