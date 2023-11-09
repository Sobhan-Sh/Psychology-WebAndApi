using Dto.Patient;
using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Dto.Test;
using Utility.Dto;

namespace Dto.Order;

public class OrderViewModel : BaseDto
{
    public PatientTurnViewModel? PatientTurnViewModel { get; set; }

    public TestViewModel? TestViewModel { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }

    public PatientViewModel PatientViewModel { get; set; }

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