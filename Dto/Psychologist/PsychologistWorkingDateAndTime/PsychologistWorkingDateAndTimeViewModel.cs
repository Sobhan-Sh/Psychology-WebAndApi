using Dto.Patient.PatientTurn;
using Dto.Psychologist.PsychologistWorkingDays;
using Dto.Psychologist.PsychologistWorkingHours;
using Utility.Dto;

namespace Dto.Psychologist.PsychologistWorkingDateAndTime;

public class PsychologistWorkingDateAndTimeViewModel : BaseDto
{
    public PsychologistViewModel PsychologistViewModel { get; set; }

    public PsychologistWorkingDaysViewModel PsychologistWorkingDaysViewModel { get; set; }

    public PsychologistWorkingHoursViewModel PsychologistWorkingHoursViewModel { get; set; }

    public List<PatientTurnViewModel> PatientTurnViewModels { get; set; }
}