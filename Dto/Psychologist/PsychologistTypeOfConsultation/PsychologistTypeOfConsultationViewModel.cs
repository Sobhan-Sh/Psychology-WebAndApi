using Dto.Psychologist.TypeOfConsultation;
using Utility.Dto;

namespace Dto.Psychologist.PsychologistTypeOfConsultation;

public class PsychologistTypeOfConsultationViewModel : BaseDto
{
    public PsychologistViewModel PsychologistViewModel { get; set; }

    public TypeOfConsultationViewModel TypeOfConsultationViewModel { get; set; }
}