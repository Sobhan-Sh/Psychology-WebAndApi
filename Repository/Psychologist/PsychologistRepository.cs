using Context;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class PsychologistRepository : GenericRepository<Entity.Psychologist.Psychologist>, IPsychologistRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}