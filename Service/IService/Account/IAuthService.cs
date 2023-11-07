using Dto.account;
using Utility.ReturnFuncResult;

namespace Service.IService.Account;

public interface IAuthService
{
    Task<BaseResult<LoginResult>> LoginAsync(Login command);

    Task<BaseResult> RegisterAsync(Register command);
}