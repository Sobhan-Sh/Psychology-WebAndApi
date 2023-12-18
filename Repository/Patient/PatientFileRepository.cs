using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;
using PD.Entity.Patient;

namespace PD.Repositories.Patient;

public class PatientFileRepository : GenericRepository<PatientFile>, IPatientFileRepository
{
    private readonly ApplicationDbContext _context;

    public PatientFileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}