using PC.Dto.Test;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Test;

public interface ITestService
{
    #region GetAll Data

    Task<BaseResult<List<TestViewModel>>> GetAllAsync(SearchTestViewModel search);
    Task<BaseResult<List<TestViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditTest>> GetAsync(int Id);
    Task<BaseResult<int>> CreateAsync(CreateTest command);
    Task<BaseResult> UpdateAsync(EditTest command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    Task<BaseResult> ActiveAsync(int Id);
    Task<BaseResult> DeActiveAsync(int Id);
}