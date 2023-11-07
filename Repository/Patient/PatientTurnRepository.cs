using Context;
using Entity.Patient;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class PatientTurnRepository : GenericRepository<PatientTurn>, IPatientTurnRepository
{
    private readonly ApplicationDbContext _context;

    public PatientTurnRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}