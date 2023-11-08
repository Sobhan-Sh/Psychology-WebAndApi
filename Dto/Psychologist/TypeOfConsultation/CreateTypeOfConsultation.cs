using Utility.Dto;

namespace Dto.Psychologist.TypeOfConsultation;

public class CreateTypeOfConsultation : BaseDto
{
    public string Name { get; set; }

    public int Price { get; set; }
}