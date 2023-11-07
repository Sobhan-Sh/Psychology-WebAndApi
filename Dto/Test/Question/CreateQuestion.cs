using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Test.Question;

public class CreateQuestion : BaseDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public int TestId { get; set; }

    [Required]
    public int PatientResponsesId { get; set; }
}