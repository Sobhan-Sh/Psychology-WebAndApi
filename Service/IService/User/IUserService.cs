using PC.Dto.User;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.User;

public interface IUserService
{
    #region GetAll Data

    Task<BaseResult<List<UserViewModel>>> GetAllAsync(SearchUserViewModel search);
    Task<BaseResult<List<UserViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditUser>> GetAsync(int Id);
    Task<BaseResult<UserViewModel>> ReturnViewGetAsync(int Id);
    Task<BaseResult> CreateAsync(CreateUser command);
    Task<BaseResult<int>> ReturnCreateAsync(CreateUser command);
    Task<BaseResult> UpdateAsync(EditUser command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    // Other Operations
    Task<BaseResult> ActivePhone(int Id);
    Task<BaseResult> BlockAsync(int Id);
    Task<BaseResult> OnBlockAsync(int Id);
    Task<BaseResult> ChangePasswordAsync(ChangePassword command);
    Task<BaseResult> ChangePasswordAsync(AdminChangePasswored command);
    Task<BaseResult<ResultFindUserAuth>> ChangeAuth(int Id);
    Task<BaseResult> ChangeAuth(ChangeAuth command);
    // Other Operations
}