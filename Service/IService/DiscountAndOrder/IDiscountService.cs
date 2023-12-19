using PC.Dto.Discount;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.DiscountAndOrder;

public interface IDiscountService
{
    public Task<BaseResult<List<DiscountViewModel>>> GetAllAsync();
    public Task<BaseResult<List<DiscountViewModel>>> GetAllAsync(SearchDiscount f);

    #region CRUD

    public Task<BaseResult<EditDiscount>> GetAsync(int Id);

    public Task<BaseResult<CreateDiscount>> GetByPatientId(int Id);

    public Task<BaseResult> CreateAsync(CreateDiscount command);

    public Task<BaseResult> UpdateAsync(EditDiscount command);

    public Task<BaseResult> DeleteAsync(int Id);

    public Task<BaseResult> DeleteByPatientIdAsync(int Id);

    #endregion
}