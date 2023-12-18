using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class PsychologistWorkingDaysRepository : GenericRepository<PsychologistWorkingDays>, IPsychologistWorkingDaysRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingDaysRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}