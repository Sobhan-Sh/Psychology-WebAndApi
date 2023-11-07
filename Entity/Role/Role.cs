using System.ComponentModel.DataAnnotations;
using Utility.Domain;

namespace Entity.Role
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<User.User> Users { get; set; }

        // Edit Role
        public void Edit(string name)
        {
            Name = name;
        }
    }
}
