using PC.Dto.User.Gender;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.User;

public interface IGenderService
{
    public Task<BaseResult<List<GenderViewModel>>> GetAllAsync();
}