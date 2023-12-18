using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;

namespace PD.Repositories.Patient;

public class PatientRepository : GenericRepository<Entity.Patient.Patient>, IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}