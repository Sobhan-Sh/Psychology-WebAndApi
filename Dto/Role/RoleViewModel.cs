using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;

namespace PC.Dto.Role;

public class RoleViewModel : BaseDto
{
    [Display(Name = "نوع دسترسی")]
    public string Name { get; set; }
}