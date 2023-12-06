using Context;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class PsychologistTypeOfConsultationRepository : GenericRepository<PsychologistTypeOfConsultation>, IPsychologistTypeOfConsultationRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistTypeOfConsultationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}