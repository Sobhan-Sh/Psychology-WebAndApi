using Context;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class PsychologistWorkingDateAndTimeRepository : GenericRepository<PsychologistWorkingDateAndTime>, IPsychologistWorkingDateAndTimeRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingDateAndTimeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}