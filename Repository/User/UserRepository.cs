using PC.Context;
using PC.Service.IRepository.User;
using PC.Utility.Data;

namespace PD.Repositories.User
{
    public class UserRepository : GenericRepository<Entity.User.User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
