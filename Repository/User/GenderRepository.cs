using PC.Context;
using PC.Service.IRepository.User;
using PC.Utility.Data;
using PD.Entity.User;

namespace PD.Repositories.User;

public class GenderRepository : GenericRepository<Gender>, IGenderRepository
{
    private readonly ApplicationDbContext _context;

    public GenderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}