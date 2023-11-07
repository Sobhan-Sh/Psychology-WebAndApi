using Context;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class PatientRepository : GenericRepository<Entity.Patient.Patient>, IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}