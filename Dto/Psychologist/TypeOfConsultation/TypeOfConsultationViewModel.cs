using Dto.Patient.PatientTurn;
using Dto.Psychologist.PsychologistTypeOfConsultation;

namespace Dto.Psychologist.TypeOfConsultation;

public class TypeOfConsultationViewModel : CreateTypeOfConsultation
{
    public List<PatientTurnViewModel> PatientTurnViewModels { get; set; }

    public List<PsychologistTypeOfConsultationViewModel> PsychologistTypeOfConsultationViewModels { get; set; }
}