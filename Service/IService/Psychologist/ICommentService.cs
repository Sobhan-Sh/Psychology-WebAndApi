using PC.Dto.Psychologist.Comment;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface ICommentService
{
    Task<BaseResult<List<CommentViewModel>>> GetAllAsync(SearchComment search);

    Task<BaseResult> CreateAsync(CreateComment command);
}