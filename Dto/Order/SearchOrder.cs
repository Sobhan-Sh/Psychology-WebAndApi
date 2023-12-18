namespace PC.Dto.Order;

public class SearchOrder
{
    public bool? IsPaid { get; set; }

    // مبلغ کل با تخفیف
    public int? PayAmount { get; set; }

    // مبلغ کل تخفیف
    public int? DiscountAmount { get; set; }

    // مبلغ کل بدون تخفیف
    public int? TotalAmount { get; set; }

    public int? PatientTurnId { get; set; }

    public int? TestId { get; set; }

    public int? PsychologistId { get; set; }
}