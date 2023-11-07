using AutoMapper;
using Dto.Test.Answer;
using Entity.Test;
using Service.IRepository.Test;
using Service.IService.Test;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Test;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<AnswerViewModel>>> GetAllAsync(SearchAnswerViewModel search)
    {
        try
        {
            IEnumerable<Answer> query = await _answerRepository.GetAllAsync(x => x.Title.Contains(search.Title) || x.QuestionId == search.QuestionId);
            if (!query.Any())
                return new BaseResult<List<AnswerViewModel>>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<List<AnswerViewModel>>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<List<AnswerViewModel>>(query),
                Message = ValidationMessage.SuccessGetAll
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<AnswerViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<AnswerViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Answer> query = await _answerRepository.GetAllAsync();
            if (!query.Any())
                return new BaseResult<List<AnswerViewModel>>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<List<AnswerViewModel>>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<List<AnswerViewModel>>(query),
                Message = ValidationMessage.SuccessGetAll
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<AnswerViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditAnswer>> GetAsync(int Id)
    {
        try
        {
            Answer query = await _answerRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult<EditAnswer>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.NoFoundGet
                };

            return new BaseResult<EditAnswer>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<EditAnswer>(query),
                Message = ValidationMessage.SuccessGet
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditAnswer>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateAnswer command)
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

            if (await _answerRepository.IsExistAsync(x => x.Title == command.Title))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            await _answerRepository.CreateAsync(_mapper.Map<Answer>(command));
            await _answerRepository.SaveAsync();
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

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        try
        {
            Answer query = await _answerRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _answerRepository.DeleteAsync(query);
            await _answerRepository.SaveAsync();
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