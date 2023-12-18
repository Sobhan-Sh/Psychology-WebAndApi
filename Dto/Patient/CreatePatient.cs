using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;

namespace PC.Dto.Patient;

public class CreatePatient : BaseDto
{
    [Required] public string NationalCode { get; set; }

    [Required] public int Age { get; set; }

    public int UserId { get; set; }

    public int PatientExamId { get; set; }

    public int TimingId { get; set; }
}