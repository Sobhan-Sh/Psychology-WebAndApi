using Dto.Test;
using Utility.ReturnFuncResult;

namespace Service.IService.Test;

public interface ITestService
{
    #region GetAll Data

    Task<BaseResult<List<TestViewModel>>> GetAllAsync(SearchTestViewModel search);
    Task<BaseResult<List<TestViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditTest>> GetAsync(int Id);
    Task<BaseResult> CreateAsync(CreateTest command);
    Task<BaseResult> UpdateAsync(EditTest command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    Task<BaseResult> ActiveAsync(int Id);
    Task<BaseResult> DeActiveAsync(int Id);
}