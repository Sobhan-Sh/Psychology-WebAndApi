using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;

namespace PD.Repositories.Psychologist;

public class PsychologistRepository : GenericRepository<Entity.Psychologist.Psychologist>, IPsychologistRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}