using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Utility.Dto;

namespace PC.Dto.Psychologist.PsychologistTypeOfConsultation;

public class PsychologistTypeOfConsultationViewModel : BaseDto
{
    public PsychologistViewModel PsychologistViewModel { get; set; }

    public TypeOfConsultationViewModel TypeOfConsultationViewModel { get; set; }
}