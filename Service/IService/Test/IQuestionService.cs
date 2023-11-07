using Dto.Test.Question;
using Utility.ReturnFuncResult;

namespace Service.IService.Test;

public interface IQuestionService
{
    #region GetAll Data

    Task<BaseResult<List<QuestionViewModel>>> GetAllAsync(SearchQustionViewModel search);
    Task<BaseResult<List<QuestionViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditQuestion>> GetAsync(int Id);
    Task<BaseResult> CreateAsync(CreateQuestion command);
    Task<BaseResult> UpdateAsync(EditQuestion command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion
}