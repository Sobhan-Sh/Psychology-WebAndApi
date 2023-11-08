using Utility.Dto;

namespace Dto.Psychologist.PsychologistWorkingHours;

public class CreatePsychologistWorkingHours : BaseDto
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}