using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PC.Utility.Dto;

namespace PC.Dto.Patient.PatientFile;

public class CreatePatientFile : BaseDto
{
    [Required] public IFormFile File { get; set; }

    public string? FilePath { get; set; }

    [Required] public int PatientId { get; set; }
}