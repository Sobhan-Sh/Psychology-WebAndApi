using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist.PsychologistWorkingDays;
using PC.Dto.Psychologist.PsychologistWorkingHours;
using PC.Utility.Dto;

namespace PC.Dto.Psychologist.PsychologistWorkingDateAndTime;

public class PsychologistWorkingDateAndTimeViewModel : BaseDto
{
    public PsychologistViewModel PsychologistViewModel { get; set; }

    public PsychologistWorkingDaysViewModel PsychologistWorkingDaysViewModel { get; set; }

    public PsychologistWorkingHoursViewModel PsychologistWorkingHoursViewModel { get; set; }

    public List<PatientTurnViewModel> PatientTurnViewModels { get; set; }
}