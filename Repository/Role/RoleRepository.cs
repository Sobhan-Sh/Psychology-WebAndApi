using PC.Context;
using PC.Service.IRepository.Role;
using PC.Utility.Data;

namespace PD.Repositories.Role;

public class RoleRepository : GenericRepository<Entity.Role.Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}