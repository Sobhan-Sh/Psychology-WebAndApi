using Dto.Order;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Dto.Psychologist.TypeOfConsultation;
using Utility.Dto;

namespace Dto.Patient.PatientTurn;

public class PatientTurnViewModel : BaseDto
{
    public DateTime ConsultationDay { get; set; }

    public int Price { get; set; }

    public bool IsVisited { get; set; }

    public bool IsCanseled { get; set; }

    public List<OrderViewModel> OrderViewModels { get; set; }

    public PsychologistWorkingDateAndTimeViewModel PsychologistWorkingDateAndTimeViewModel { get; set; }

    public TypeOfConsultationViewModel TypeOfConsultationViewModel { get; set; }

    public PatientViewModel PatientViewModel { get; set; }
}