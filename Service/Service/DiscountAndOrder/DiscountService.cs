using Dto.Discount;
using Service.IRepository.DiscountAndOrder;
using Service.IService.DiscountAndOrder;
using Utility.ReturnFuncResult;

namespace Service.Service.DiscountAndOrder;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<BaseResult<DiscountViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<DiscountViewModel>> GetAllAsync(SearchDiscount f)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditDiscount>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreateDiscount command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditDiscount command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}