using System.ComponentModel.DataAnnotations;
using Utility.Dto;
using Utility.ReturnError;

namespace Dto.Test;

public class CreateTest : BaseDto
{
    [Display(Name = "نام آزمون")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    public string Title { get; set; }

    [Display(Name = "توضیحات آزمون")]
    public string? Description { get; set; }

    [Display(Name = "قیمت آزمون")]
    [Required(ErrorMessage = ErrorHandling.Required)]
    [Range(1, int.MaxValue, ErrorMessage = ErrorHandling.Range)]
    public int Price { get; set; }
}