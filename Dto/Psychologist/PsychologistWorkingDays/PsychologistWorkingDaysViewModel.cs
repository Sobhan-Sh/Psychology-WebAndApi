using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;

namespace PC.Dto.Psychologist.PsychologistWorkingDays;

public class PsychologistWorkingDaysViewModel : CreatePsychologistWorkingDays
{
    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimeViewModels { get; set; }
}