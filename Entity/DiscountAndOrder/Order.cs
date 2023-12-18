using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;
using PD.Entity.Patient;

namespace PD.Entity.DiscountAndOrder;

public class Order : BaseEntity
{
    public int? PatientTurnId { get; set; }
    [ForeignKey("PatientTurnId")]
    public PatientTurn? PatientTurn { get; set; }

    public int? TestId { get; set; }
    [ForeignKey("TestId")]
    public Test.Test? Test { get; set; }

    public int? PsychologistId { get; set; }
    [ForeignKey("PsychologistId")]
    public Psychologist.Psychologist Psychologist { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient.Patient Patient { get; set; }

    public bool IsPaid { get; set; }

    public int? RefId { get; set; }

    // مبلغ کل با تخفیف
    public int? PayAmount { get; set; }

    // مبلغ کل تخفیف
    public int? DiscountAmount { get; set; }

    // مبلغ کل بدون تخفیف
    public int TotalAmount { get; set; }

    public string? Description { get; set; }

    public void Edit(int? payAmount, int? discountAmount, int? totalAmount, string? description, bool isPaid)
    {
        TotalAmount = (int)totalAmount;
        PayAmount = (int)payAmount;
        DiscountAmount = (int)discountAmount;
        IsPaid = isPaid;
        UpdatedAt = DateTime.Now;
    }

    public void PaymentSuccess(int refId)
    {
        IsPaid = true;
        RefId = refId;
        IsActive = true;
    }
}