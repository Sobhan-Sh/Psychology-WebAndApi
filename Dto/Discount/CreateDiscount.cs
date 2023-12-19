using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;
using PC.Utility.ReturnError;

namespace PC.Dto.Discount;

public class CreateDiscount : BaseDto
{
    public int PatientId { get; set; }

    public int PsychologistId { get; set; }

    [Display(Name = "تخفیف با پول")]
    [Range(minimum: 20000, maximum: 300000, ErrorMessage = ErrorHandling.Range)]
    public int? DiscountWithMoney { get; set; }

    [Display(Name = "تخفیف با درصد")]
    public int? DiscountWithPercentage { get; set; }
}