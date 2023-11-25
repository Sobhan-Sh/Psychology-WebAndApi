using Utility.Domain;

namespace Entity.User;

public class Gender : BaseEntity
{
    public string Name { get; set; }

    public List<User> Users { get; set; }
}