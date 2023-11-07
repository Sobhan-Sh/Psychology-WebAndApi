using Context;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class PsychologistWorkingHoursRepository : GenericRepository<PsychologistWorkingHours>, IPsychologistWorkingHoursRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingHoursRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}