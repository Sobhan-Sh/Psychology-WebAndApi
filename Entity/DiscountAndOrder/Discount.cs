using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;

namespace PD.Entity.DiscountAndOrder;

public class Discount : BaseEntity
{
    public int? PatientId { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient.Patient Patient { get; set; }

    public int? PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public virtual Psychologist.Psychologist Psychologist { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }

    public void Edit(int? discountWithMoney, int? discountWithPercentage)
    {
        DiscountWithMoney = discountWithMoney;
        DiscountWithPercentage = discountWithPercentage;
    }
}