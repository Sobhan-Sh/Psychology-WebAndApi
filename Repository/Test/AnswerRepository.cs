using PC.Context;
using PC.Service.IRepository.Test;
using PC.Utility.Data;
using PD.Entity.Test;

namespace PD.Repositories.Test;

public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
{
    private readonly ApplicationDbContext _context;

    public AnswerRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}