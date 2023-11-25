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
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public AnswerService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
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

            if (!await _questionRepository.IsExistAsync(x => x.Id == command.QuestionId))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFoundSectionAnswerErrorQuestion,
                    StatusCode = ValidationCode.BadRequest
                };

            command.IsActive = true;
            command.CreatedAt = DateTime.Now.ToString();
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

    public async Task<BaseResult<CreateAnswer>> ReturnCreateAsync(CreateAnswer command)
    {
        try
        {
            if (command == null)
                return new BaseResult<CreateAnswer>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            if (!await _questionRepository.IsExistAsync(x => x.Id == command.QuestionId))
                return new BaseResult<CreateAnswer>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFoundSectionAnswerErrorQuestion,
                    StatusCode = ValidationCode.BadRequest
                };

            if (await _answerRepository.IsExistAsync(x => x.Title == command.Title))
                return new BaseResult<CreateAnswer>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            Answer answer = await _answerRepository.ReturnCreateAsync(_mapper.Map<Answer>(command));
            await _answerRepository.SaveAsync();
            return new BaseResult<CreateAnswer>()
            {
                IsSuccess = true,
                StatusCode = ValidationCode.Success,
                Message = ValidationMessage.SuccessCreate,
                Data = _mapper.Map<CreateAnswer>(answer)
            };
        }
        catch (Exception e)
        {
            return new BaseResult<CreateAnswer>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateRangeAsync(List<CreateAnswer> command)
    {
        try
        {
            if (!command.Any())
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            for (int i = 0; i < command.Count; i++)
            {
                if (!await _questionRepository.IsExistAsync(x => x.Id == command[i].QuestionId))
                    return new BaseResult
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.RecordNotFoundSectionAnswerErrorQuestion,
                        StatusCode = ValidationCode.BadRequest
                    };
            }

            foreach (var item in command)
            {
                if (await _answerRepository.IsExistAsync(x => x.Title == item.Title))
                    return new BaseResult
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.DuplicatedRecord,
                        StatusCode = ValidationCode.BadRequest
                    };
            }

            await _answerRepository.CreateRangeAsync(_mapper.Map<List<Answer>>(command));
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

    public async Task<BaseResult> UpdateAnswersInQuestionAsync(CreateAnswer command)
    {
        try
        {
            Question query = await _questionRepository.GetAsync(x => x.Id == command.QuestionId);
            IEnumerable<Question> questions = await _questionRepository.GetAllAsync(x => x.TestId == query.TestId);
            foreach (var question in questions)
            {
                if (question.Id != command.QuestionId)
                {
                    await _answerRepository.CreateAsync(new Answer()
                    {
                        CreatedAt = DateTime.Now,
                        Description = command.Description,
                        IsActive = true,
                        QuestionId = question.Id,
                        Score = command.Score,
                        Title = command.Title,
                    });
                }
            }

            await _answerRepository.SaveAsync();
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

    public async Task<BaseResult> DeleteAllAnswerQuestionsAsync(int answerId)
    {
        try
        {
            Answer query = await _answerRepository.GetAsync(x => x.Id == answerId);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            IEnumerable<Answer> answers = await _answerRepository.GetAllAsync(x => x.Title == query.Title);
            foreach (var answer in answers)
            {
                await _answerRepository.DeleteAsync(answer);
            }

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