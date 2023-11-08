using Dto.Order;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.Psychologist.TypeOfConsultation;

namespace Dto.Patient.PatientTurn;

public class PatientTurnViewModel : CreatePatientTurn
{
    public List<OrderViewModel> Order { get; set; }

    public PsychologistWorkingDateAndTimeViewModel PsychologistWorkingDateAndTime { get; set; }

    public TypeOfConsultationViewModel TypeOfConsultation { get; set; }

    public PatientViewModel Patient { get; set; }
}