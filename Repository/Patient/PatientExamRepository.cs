using Context;
using Entity.Patient;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class PatientExamRepository : GenericRepository<PatientExam>, IPatientExamRepository
{
    private readonly ApplicationDbContext _context;

    public PatientExamRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}