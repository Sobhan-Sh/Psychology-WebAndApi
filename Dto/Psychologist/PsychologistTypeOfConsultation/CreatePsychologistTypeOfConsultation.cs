using Utility.Dto;

namespace Dto.Psychologist.PsychologistTypeOfConsultation;

public class CreatePsychologistTypeOfConsultation : BaseDto
{
    public int PsychologistId { get; set; }

    public int TypeOfConsultationId { get; set; }
}