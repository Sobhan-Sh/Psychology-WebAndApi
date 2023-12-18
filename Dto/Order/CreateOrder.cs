using PC.Utility.Dto;

namespace PC.Dto.Order;

public class CreateOrder : BaseDto
{
    public int? PatientTurnId { get; set; }

    public int? TestId { get; set; }

    public int? PsychologistId { get; set; }

    public int PatientId { get; set; }

    public bool IsPaid { get; set; }

    public int? RefId { get; set; }

    // مبلغ کل با تخفیف
    public int? PayAmount { get; set; }

    // مبلغ کل تخفیف
    public int? DiscountAmount { get; set; }

    // مبلغ کل بدون تخفیف
    public int TotalAmount { get; set; }

    public string? Description { get; set; }
}