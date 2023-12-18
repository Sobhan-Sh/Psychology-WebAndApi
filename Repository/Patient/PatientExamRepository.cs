using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;
using PD.Entity.Patient;

namespace PD.Repositories.Patient;

public class PatientExamRepository : GenericRepository<PatientExam>, IPatientExamRepository
{
    private readonly ApplicationDbContext _context;

    public PatientExamRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}