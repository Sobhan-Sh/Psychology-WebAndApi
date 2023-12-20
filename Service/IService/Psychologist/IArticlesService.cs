using PC.Dto.Psychologist.Article;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface IArticlesService
{
    #region Get All Data

    Task<BaseResult<List<ArticleViewModel>>> GetAllAsync(SearchArticle search);

    Task<BaseResult<List<ArticleViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditArticle>> GetAsync(int Id);

    Task<BaseResult> CreateAsync(CreateArticle command);

    Task<BaseResult> UpdateAsync(EditArticle command);

    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    Task<BaseResult> ActiveAsync(int Id);

    Task<BaseResult> DeActiveAsync(int Id);
}