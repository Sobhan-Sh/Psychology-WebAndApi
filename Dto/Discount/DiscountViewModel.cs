using PC.Dto.Patient;
using PC.Dto.Psychologist;
using PC.Utility.Dto;

namespace PC.Dto.Discount;

public class DiscountViewModel : BaseDto
{
    public PatientViewModel PatientViewModel { get; set; }

    public PsychologistViewModel PsychologistViewModel { get; set; }

    public int? DiscountWithMoney { get; set; }

    public int? DiscountWithPercentage { get; set; }
}