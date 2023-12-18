using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;
using PD.Entity.Patient;

namespace PD.Repositories.Patient;

public class PatientTurnRepository : GenericRepository<PatientTurn>, IPatientTurnRepository
{
    private readonly ApplicationDbContext _context;

    public PatientTurnRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}