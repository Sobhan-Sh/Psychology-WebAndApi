using Context;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class PsychologistWorkingDaysRepository : GenericRepository<PsychologistWorkingDays>, IPsychologistWorkingDaysRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingDaysRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}