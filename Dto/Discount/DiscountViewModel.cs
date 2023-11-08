using Dto.Patient;
using Dto.Psychologist;

namespace Dto.Discount;

public class DiscountViewModel
{
    public PatientViewModel Patient { get; set; }

    public PsychologistViewModel Psychologist { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}