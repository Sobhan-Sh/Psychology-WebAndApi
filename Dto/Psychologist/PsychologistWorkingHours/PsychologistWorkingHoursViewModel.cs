using Dto.Psychologist.PsychologistWorkingDateAndTime;

namespace Dto.Psychologist.PsychologistWorkingHours;

public class PsychologistWorkingHoursViewModel : CreatePsychologistWorkingHours
{
    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimes { get; set; }
}