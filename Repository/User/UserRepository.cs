using Context;
using Service.IRepository.User;
using Utility.Data;

namespace Repositories.User
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
