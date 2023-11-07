using Context;
using Entity.DiscountAndOrder;
using Service.IRepository.DiscountAndOrder;
using Utility.Data;

namespace Repositories.DiscountAndOrder;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}