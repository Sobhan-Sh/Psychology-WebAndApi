using Utility.Dto;

namespace Dto.Psychologist.PsychologistWorkingDays;

public class CreatePsychologistWorkingDays : BaseDto
{
    public string Day { get; set; }

    public string DayEn { get; set; }
}