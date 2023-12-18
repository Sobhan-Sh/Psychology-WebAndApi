using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class PsychologistWorkingHoursRepository : GenericRepository<PsychologistWorkingHours>, IPsychologistWorkingHoursRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingHoursRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}