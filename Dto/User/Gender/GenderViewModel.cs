using System.ComponentModel.DataAnnotations;
using Utility.Dto;

namespace Dto.User.Gender;

public class GenderViewModel : BaseDto
{
    [Display(Name = "جنسیت")]
    public string Name { get; set; }

    public List<UserViewModel> UsersViewModels { get; set; }
}