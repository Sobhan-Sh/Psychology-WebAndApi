using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Patient.Timing;

public class CreateTiming : BaseDto
{
    [Required]
    public DateTime DateTimeVisit { get; set; }

    public string? TimeVisit { get; set; }

    public bool FullOfTime { get; set; }
}