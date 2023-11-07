using Context;
using Entity.DiscountAndOrder;
using Service.IRepository.DiscountAndOrder;
using Utility.Data;

namespace Repositories.DiscountAndOrder;

public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
{
    private readonly ApplicationDbContext _context;

    public DiscountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}