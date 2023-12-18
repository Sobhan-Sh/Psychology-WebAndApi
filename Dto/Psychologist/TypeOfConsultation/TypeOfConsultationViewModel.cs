using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist.PsychologistTypeOfConsultation;

namespace PC.Dto.Psychologist.TypeOfConsultation;

public class TypeOfConsultationViewModel : CreateTypeOfConsultation
{
    public List<PatientTurnViewModel> PatientTurnViewModels { get; set; }

    public List<PsychologistTypeOfConsultationViewModel> PsychologistTypeOfConsultationViewModels { get; set; }
}