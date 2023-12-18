using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class PsychologistWorkingDateAndTimeRepository : GenericRepository<PsychologistWorkingDateAndTime>, IPsychologistWorkingDateAndTimeRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistWorkingDateAndTimeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}