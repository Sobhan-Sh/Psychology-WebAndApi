using Dto.Order;
using Utility.ReturnFuncResult;

namespace Service.IService.DiscountAndOrder;

public interface IOrderService
{
    public Task<BaseResult<OrderViewModel>> GetAllAsync();
    public Task<BaseResult<OrderViewModel>> GetAllAsync(SearchOrder f);

    #region CRUD

    public Task<BaseResult<EditOrder>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreateOrder command);

    public Task<BaseResult> UpdateAsync(EditOrder command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}