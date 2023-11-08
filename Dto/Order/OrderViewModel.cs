using Dto.Patient;
using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Dto.Test;
using Utility.Dto;

namespace Dto.Order;

public class OrderViewModel : BaseDto
{
    public PatientTurnViewModel? PatientTurn { get; set; }

    public TestViewModel? Test { get; set; }

    public PsychologistViewModel Psychologist { get; set; }

    public PatientViewModel Patient { get; set; }

    public bool IsPaid { get; set; }

    public int RefId { get; set; }

    // مبلغ کل با تخفیف
    public int PayAmount { get; set; }

    // مبلغ کل تخفیف
    public int DiscountAmount { get; set; }

    // مبلغ کل بدون تخفیف
    public int TotalAmount { get; set; }

    public string? Description { get; set; }
}