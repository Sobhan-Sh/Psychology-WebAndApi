using Dto.Discount;
using Utility.ReturnFuncResult;

namespace Service.IService.DiscountAndOrder;

public interface IDiscountService
{
    public Task<BaseResult<DiscountViewModel>> GetAllAsync();
    public Task<BaseResult<DiscountViewModel>> GetAllAsync(SearchDiscount f);

    #region CRUD

    public Task<BaseResult<EditDiscount>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreateDiscount command);

    public Task<BaseResult> UpdateAsync(EditDiscount command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}