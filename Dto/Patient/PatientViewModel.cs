using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Patient;

public class PatientViewModel : BaseDto
{
    [Required]
    public string NationalCode { get; set; }

    [Required]
    public int Age { get; set; }

    public int UserId { get; set; }

    public int PatientExamId { get; set; }
}