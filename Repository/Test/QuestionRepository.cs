using PC.Context;
using PC.Service.IRepository.Test;
using PC.Utility.Data;
using PD.Entity.Test;

namespace PD.Repositories.Test;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}