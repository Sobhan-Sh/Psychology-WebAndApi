using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Utility.Data;
using PD.Entity.Psychologist;

namespace PD.Repositories.Psychologist;

public class ArticlesRepository : GenericRepository<Article>, IArticlesRepository
{
    private readonly ApplicationDbContext _context;

    public ArticlesRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}