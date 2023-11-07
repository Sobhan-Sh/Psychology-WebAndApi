using Dto.Order;
using Service.IRepository.DiscountAndOrder;
using Service.IService.DiscountAndOrder;
using Utility.ReturnFuncResult;

namespace Service.Service.DiscountAndOrder;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<BaseResult<OrderViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<OrderViewModel>> GetAllAsync(SearchOrder f)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditOrder>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreateOrder command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditOrder command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}