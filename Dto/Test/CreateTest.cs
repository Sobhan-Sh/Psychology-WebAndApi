using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Test;

public class CreateTest : BaseDto
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }
}