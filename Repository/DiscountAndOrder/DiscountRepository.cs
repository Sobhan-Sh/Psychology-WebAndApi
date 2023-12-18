using PC.Context;
using PC.Service.IRepository.DiscountAndOrder;
using PC.Utility.Data;
using PD.Entity.DiscountAndOrder;

namespace PD.Repositories.DiscountAndOrder;

public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
{
    private readonly ApplicationDbContext _context;

    public DiscountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}