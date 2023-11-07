using Context;
using Entity.Test;
using Service.IRepository.Test;
using Utility.Data;

namespace Repositories.Test;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}