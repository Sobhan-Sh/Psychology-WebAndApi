using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class PsychologistAboutUsRepository : GenericRepository<PsychologistAboutUs>, IPsychologistAboutUsRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistAboutUsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}