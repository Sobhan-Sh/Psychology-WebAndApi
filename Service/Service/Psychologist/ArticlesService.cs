using AutoMapper;
using PC.Dto.Psychologist.Article;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.Psychologist;

namespace PC.Service.Service.Psychologist;

public class ArticlesService : IArticlesService
{
    private readonly IArticlesRepository _articlesRepository;
    private IMapper _mapper;

    public ArticlesService(IArticlesRepository articlesRepository, IMapper mapper)
    {
        _articlesRepository = articlesRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<ArticleViewModel>>> GetAllAsync(SearchArticle search)
    {
        try
        {
            List<Article> query = new List<Article>();
            if (string.IsNullOrWhiteSpace(search.Title) && search.PsychologistId < 1)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }
            else
            {
                IEnumerable<Article> articles = await _articlesRepository.GetAllAsync(include: "Psychologist.User");
                query.AddRange(articles.Where(x =>
                {
                    bool psId = search.PsychologistId < 0 || x.PsychologistId == search.PsychologistId;
                    bool title = string.IsNullOrWhiteSpace(search.Title) || x.Title.Contains(search.Title);
                    return psId && title;
                }).Distinct().ToList());
            }

            if (!query.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success,
                    Data = new List<ArticleViewModel>()
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Count()),
                Data = _mapper.Map<List<ArticleViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<ArticleViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Article> query = await _articlesRepository.GetAllAsync(include: "Psychologist.User");
            if (!query.Any())
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<ArticleViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditArticle>> GetAsync(int Id)
    {
        try
        {
            Article query = await _articlesRepository.GetAsync(x => x.Id == Id, include: "Psychologist");
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditArticle>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<ArticleViewModel>> GetArticleViewModelAsync(int Id)
    {
        try
        {
            Article query = await _articlesRepository.GetAsync(x => x.Id == Id, include: "Psychologist.User");
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<ArticleViewModel>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateArticle command)
    {
        try
        {
            if (command == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            if (await _articlesRepository.IsExistAsync(x => x.Title == command.Title))
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            command.CreatedAt = DateTime.Now.ToString();
            command.IsActive = false;
            await _articlesRepository.CreateAsync(_mapper.Map<Article>(command));
            await _articlesRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreateArticle,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> UpdateAsync(EditArticle command)
    {
        try
        {
            if (!await _articlesRepository.IsExistAsync(x => x.Id == command.Id))
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            Article query = await _articlesRepository.GetAsync(x => x.Id == command.Id);
            query.Edit(command.Title, command.Text);
            await _articlesRepository.SaveAsync();
            return new()
            {
                Message = ValidationMessage.SuccessUpdateArticle,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorUpdate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        try
        {
            Article query = await _articlesRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Delete();
            await _articlesRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> ActiveAsync(int Id)
    {
        Article psychologist = await _articlesRepository.GetAsync(x => x.Id == Id);
        if (psychologist == null)
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        psychologist.Active();
        await _articlesRepository.SaveAsync();
        return new()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActive,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> DeActiveAsync(int Id)
    {
        Article psychologist = await _articlesRepository.GetAsync(x => x.Id == Id);
        if (psychologist == null)
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        psychologist.DeActive();
        await _articlesRepository.SaveAsync();
        return new()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessDeActive,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> RestorAsync(int Id)
    {
        Article psychologist = await _articlesRepository.GetAsync(x => x.Id == Id);
        if (psychologist == null)
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        psychologist.Resotr();
        await _articlesRepository.SaveAsync();
        return new()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessRestor,
            StatusCode = ValidationCode.Success
        };
    }
}