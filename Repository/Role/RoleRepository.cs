using Context;
using Service.IRepository.Role;
using Utility.Data;

namespace Repositories.Role;

public class RoleRepository : GenericRepository<Entity.Role.Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}