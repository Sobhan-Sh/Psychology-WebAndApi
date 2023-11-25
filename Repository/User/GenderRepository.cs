using Context;
using Entity.User;
using Service.IRepository.User;
using Utility.Data;

namespace Repositories.User;

public class GenderRepository : GenericRepository<Gender>, IGenderRepository
{
    private readonly ApplicationDbContext _context;

    public GenderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}