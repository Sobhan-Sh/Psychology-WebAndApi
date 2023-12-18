using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class PsychologistTypeOfConsultationRepository : GenericRepository<PsychologistTypeOfConsultation>, IPsychologistTypeOfConsultationRepository
{
    private readonly ApplicationDbContext _context;

    public PsychologistTypeOfConsultationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}