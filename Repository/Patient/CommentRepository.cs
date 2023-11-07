using Context;
using Entity.Patient;
using Service.IRepository.Patient;
using Utility.Data;

namespace Repositories.Patient;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}