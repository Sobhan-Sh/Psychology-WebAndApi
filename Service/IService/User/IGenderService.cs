using Dto.User.Gender;
using Utility.ReturnFuncResult;

namespace Service.IService.User;

public interface IGenderService
{
    public Task<BaseResult<List<GenderViewModel>>> GetAllAsync();
}