using PC.Dto.Order;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Utility.Dto;

namespace PC.Dto.Patient.PatientTurn;

public class PatientTurnViewModel : BaseDto
{
    public string ConsultationDay { get; set; }

    public int Price { get; set; }

    public bool IsVisited { get; set; }

    public bool IsCanseled { get; set; }

    public List<OrderViewModel> OrderViewModels { get; set; }

    public PsychologistWorkingDateAndTimeViewModel PsychologistWorkingDateAndTimeViewModel { get; set; }

    public TypeOfConsultationViewModel TypeOfConsultationViewModel { get; set; }

    public PatientViewModel PatientViewModel { get; set; }
}