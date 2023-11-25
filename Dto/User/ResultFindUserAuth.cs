using Dto.Role;

namespace Dto.User;

public class ResultFindUserAuth
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public List<RoleViewModel> RoleViewModels { get; set; }
}