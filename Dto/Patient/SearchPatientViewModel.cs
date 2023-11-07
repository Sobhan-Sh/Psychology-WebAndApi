using System.ComponentModel.DataAnnotations;

namespace Dto.Patient;

public class SearchPatientViewModel
{
    [Required]
    public string NationalCode { get; set; }
}