using System.ComponentModel.DataAnnotations;
using PC.Utility.Dto;

namespace PC.Dto.User.Gender;

public class GenderViewModel : BaseDto
{
    [Display(Name = "جنسیت")]
    public string Name { get; set; }

    public List<UserViewModel> UsersViewModels { get; set; }
}