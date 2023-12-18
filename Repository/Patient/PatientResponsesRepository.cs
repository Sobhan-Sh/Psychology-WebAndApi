using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;
using PD.Entity.Patient;

namespace PD.Repositories.Patient;

public class PatientResponsesRepository : GenericRepository<PatientResponses>, IPatientResponsRepository
{
    private readonly ApplicationDbContext _context;

    public PatientResponsesRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}