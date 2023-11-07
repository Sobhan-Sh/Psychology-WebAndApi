using Context;
using Entity.Test;
using Service.IRepository.Test;
using Utility.Data;

namespace Repositories.Test;

public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
{
    private readonly ApplicationDbContext _context;

    public AnswerRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}