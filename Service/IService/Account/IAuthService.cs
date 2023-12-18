using PC.Dto.account;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Account;

public interface IAuthService
{
    Task<BaseResult<LoginResult>> LoginAsync(Login command);

    Task<BaseResult> RegisterAsync(Register command);
}