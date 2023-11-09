using Dto.Psychologist.PsychologistWorkingDateAndTime;

namespace Dto.Psychologist.PsychologistWorkingDays;

public class PsychologistWorkingDaysViewModel : CreatePsychologistWorkingDays
{
    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimeViewModels { get; set; }
}