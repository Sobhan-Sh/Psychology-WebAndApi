using Context;
using Entity.Patient;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class PatientResponsesRepository : GenericRepository<PatientResponses>, IPatientResponsRepository
{
    private readonly ApplicationDbContext _context;

    public PatientResponsesRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}