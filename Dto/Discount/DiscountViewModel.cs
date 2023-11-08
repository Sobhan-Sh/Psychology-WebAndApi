using Dto.Patient;
using Dto.Psychologist;
using Utility.Dto;

namespace Dto.Discount;

public class DiscountViewModel : BaseDto
{
    public PatientViewModel Patient { get; set; }

    public PsychologistViewModel Psychologist { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}