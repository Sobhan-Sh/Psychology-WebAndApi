using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class TypeOfConsultationRepository : GenericRepository<TypeOfConsultation>, ITypeOfConsultationRepository
{
    private readonly ApplicationDbContext _context;

    public TypeOfConsultationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}