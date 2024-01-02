using PC.Dto.Order;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.DiscountAndOrder;

public interface IOrderService
{
    public Task<BaseResult<List<OrderViewModel>>> GetAllAsync();
    public Task<BaseResult<List<OrderViewModel>>> GetAllAsync(SearchOrder f);
    public Task<BaseResult<List<OrderViewModel>>> GetAllAsync(int Id) ;

    #region CRUD

    public Task<BaseResult<EditOrder>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreateOrder command);

    public Task<BaseResult> UpdateAsync(EditOrder command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion

    public Task<BaseResult> PaymentSuccessAsync(PaymentSuccess command);
}