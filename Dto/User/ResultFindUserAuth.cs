using PC.Dto.Role;

namespace PC.Dto.User;

public class ResultFindUserAuth
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public List<RoleViewModel> RoleViewModels { get; set; }
}