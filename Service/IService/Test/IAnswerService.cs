using PC.Dto.Test.Answer;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Test;

public interface IAnswerService
{
    #region GetAll Data

    Task<BaseResult<List<AnswerViewModel>>> GetAllAsync(SearchAnswerViewModel search);
    Task<BaseResult<List<AnswerViewModel>>> GetAllAsync();

    #endregion

    #region CRD

    Task<BaseResult<EditAnswer>> GetAsync(int Id);
    Task<BaseResult> CreateAsync(CreateAnswer command);
    Task<BaseResult<CreateAnswer>> ReturnCreateAsync(CreateAnswer command);
    Task<BaseResult> CreateRangeAsync(List<CreateAnswer> command);
    Task<BaseResult> UpdateAnswersInQuestionAsync(CreateAnswer command);
    Task<BaseResult> DeleteAsync(int Id);
    Task<BaseResult> DeleteAllAnswerQuestionsAsync(int answerId);

    #endregion
}