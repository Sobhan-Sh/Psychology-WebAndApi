using Context;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Utility.Data;

namespace Repositories.Psychologist;

public class TypeOfConsultationRepository : GenericRepository<TypeOfConsultation>, ITypeOfConsultationRepository
{
    private readonly ApplicationDbContext _context;

    public TypeOfConsultationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}