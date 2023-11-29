using Utility.Dto;

namespace Dto.Patient;

public class PatientViewModel : BaseDto
{
    public string NationalCode { get; set; }

    public int Age { get; set; }

    public int UserId { get; set; }

    public int PatientExamId { get; set; }
}