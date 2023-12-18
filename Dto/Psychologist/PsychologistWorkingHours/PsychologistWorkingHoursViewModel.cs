using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;

namespace PC.Dto.Psychologist.PsychologistWorkingHours;

public class PsychologistWorkingHoursViewModel : CreatePsychologistWorkingHours
{
    public List<PsychologistWorkingDateAndTimeViewModel> PsychologistWorkingDateAndTimeViewModels { get; set; }
}