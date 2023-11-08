using Dto.Patient.PatientTurn;

namespace Dto.Psychologist.PsychologistWorkingDateAndTime;

public class PsychologistWorkingDateAndTimeViewModel : CreatePsychologistWorkingDateAndTime
{
    public List<PatientTurnViewModel> PatientTurns { get; set; }
}