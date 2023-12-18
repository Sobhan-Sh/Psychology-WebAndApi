using PC.Utility.Dto;

namespace PC.Dto.Psychologist.PsychologistWorkingDays;

public class CreatePsychologistWorkingDays : BaseDto
{
    public string Day { get; set; }

    public string DayEn { get; set; }
}