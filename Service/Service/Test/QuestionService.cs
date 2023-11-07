using AutoMapper;
using Dto.Test.Question;
using Entity.Test;
using Service.IRepository.Test;
using Service.IService.Test;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Test;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<QuestionViewModel>>> GetAllAsync(SearchQustionViewModel search)
    {
        try
        {
            IEnumerable<Question> query = await _questionRepository.GetAllAsync(x => x.TestId == search.TestId);
            if (!query.Any())
                return new BaseResult<List<QuestionViewModel>>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<List<QuestionViewModel>>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<List<QuestionViewModel>>(query),
                Message = ValidationMessage.SuccessGetAll
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<QuestionViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<QuestionViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Question> query = await _questionRepository.GetAllAsync();
            if (!query.Any())
                return new BaseResult<List<QuestionViewModel>>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<List<QuestionViewModel>>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<List<QuestionViewModel>>(query),
                Message = ValidationMessage.SuccessGetAll
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<QuestionViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditQuestion>> GetAsync(int Id)
    {
        try
        {
            Question query = await _questionRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult<EditQuestion>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<EditQuestion>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<EditQuestion>(query),
                Message = ValidationMessage.SuccessGet
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditQuestion>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateQuestion command)
    {
        try
        {
            if (command == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            if (await _questionRepository.IsExistAsync(x => x.Title == command.Title))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            await _questionRepository.CreateAsync(_mapper.Map<Question>(command));
            await _questionRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Message = ValidationMessage.SuccessCreate
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> UpdateAsync(EditQuestion command)
    {
        try
        {
            Question query = await _questionRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.Title);
            await _questionRepository.SaveAsync();
            return new BaseResult()
            {
                Message = ValidationMessage.SuccessUpdate,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
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
            Question query = await _questionRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (await _answerRepository.IsExistAsync(x => x.QuestionId == Id))
                foreach (var subItem in await _answerRepository.GetAllAsync(x => x.QuestionId == Id))
                {
                    await _answerRepository.DeleteAsync(subItem);
                }

            await _questionRepository.DeleteAsync(query);
            await _questionRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}