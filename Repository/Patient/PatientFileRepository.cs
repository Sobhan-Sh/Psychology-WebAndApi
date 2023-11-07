using Context;
using Entity.Patient;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class PatientFileRepository : GenericRepository<PatientFile>, IPatientFileRepository
{
    private readonly ApplicationDbContext _context;

    public PatientFileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}