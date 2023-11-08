namespace Dto.Discount;

public class CreateDiscount
{
    public int PatientId { get; set; }

    public int PsychologistId { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}