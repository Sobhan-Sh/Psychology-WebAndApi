using Dto.Patient;
using Dto.Psychologist;
using Utility.Dto;

namespace Dto.Discount;

public class DiscountViewModel : BaseDto
{
    public PatientViewModel PatientViewModel { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}