using PC.Dto.Test.Question;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Test;

public interface IQuestionService
{
    #region GetAll Data

    Task<BaseResult<List<QuestionViewModel>>> GetAllAsync(SearchQustionViewModel search);
    Task<BaseResult<List<QuestionViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditQuestion>> GetAsync(int Id);
    Task<BaseResult<QuestionViewModel>> GetQuestionViewModelAsync(int Id);
    Task<BaseResult<CreateQuestion>> CreateAsync(CreateQuestion command);
    Task<BaseResult<CreateQuestion>> CreateQuestionAndAnswer(CreateQuestion command);
    Task<BaseResult<List<CreateQuestion>>> CreateRangeAsync(List<CreateQuestion> command);
    Task<BaseResult> UpdateAsync(EditQuestion command);
    Task<BaseResult> DeleteAsync(int Id);
    Task<BaseResult<int>> ReturnDeleteAsync(int Id);

    #endregion
}