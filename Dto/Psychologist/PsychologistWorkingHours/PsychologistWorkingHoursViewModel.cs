using Dto.Psychologist.PsychologistWorkingDateAndTime;

namespace Dto.Psychologist.PsychologistWorkingHours;

public class PsychologistWorkingHoursViewModel : CreatePsychologistWorkingHours
{
    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimeViewModels { get; set; }
}