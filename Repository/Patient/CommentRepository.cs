using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Utility.Data;
using PD.Entity.Patient;

namespace PD.Repositories.Patient;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}