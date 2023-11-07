using Dto.Role;
using Utility.Dto;

namespace Dto.User;

public class UserViewModel : BaseDto
{
    public string FName { get; set; }

    public string LName { get; set; }

    public string Phone { get; set; }

    public string? Address { get; set; }

    public string Password { get; set; }

    public bool MobailActiveStatus { get; set; }

    public string ActivationCode { get; set; }

    public string? Avatar { get; set; }

    public RoleViewModel RoleViewModel { get; set; }
}