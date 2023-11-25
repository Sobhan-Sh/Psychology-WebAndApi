using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.Role;

public class RoleViewModel : BaseDto
{
    [Display(Name = "نوع دسترسی")]
    public string Name { get; set; }
}