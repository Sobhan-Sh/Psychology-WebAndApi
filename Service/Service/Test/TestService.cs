using AutoMapper;
using Dto.Test;
using Service.IRepository.Test;
using Service.IService.Test;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Test;

public class TestService : ITestService
{
    private readonly ITestRepository _repository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public TestService(ITestRepository repository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IMapper mapper)
    {
        _repository = repository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<TestViewModel>>> GetAllAsync(SearchTestViewModel search)
    {
        try
        {
            IEnumerable<Entity.Test.Test> query = await _repository.GetAllAsync(x => x.Title.Contains(search.Title));
            if (!query.Any())
            {
                return new BaseResult<List<TestViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    Data = new List<TestViewModel>(),
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<TestViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Count()),
                Data = _mapper.Map<List<TestViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<TestViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<TestViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Test.Test> query = await _repository.GetAllAsync(include: "Question");
            if (!query.Any())
            {
                return new BaseResult<List<TestViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    Data = new List<TestViewModel>(),
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<TestViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<TestViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<TestViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditTest>> GetAsync(int Id)
    {
        try
        {
            Entity.Test.Test query = await _repository.GetAsync(x => x.Id == Id);
            if (query == null)
            {
                return new BaseResult<EditTest>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditTest>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditTest>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditTest>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateTest command)
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

            if (await _repository.IsExistAsync(x => x.Title == command.Title))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            await _repository.CreateAsync(_mapper.Map<Entity.Test.Test>(command));
            await _repository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreate,
                StatusCode = ValidationCode.Success
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

    public async Task<BaseResult> UpdateAsync(EditTest command)
    {
        try
        {
            Entity.Test.Test query = await _repository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.Title, command.Description);
            await _repository.SaveAsync();
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
            Entity.Test.Test query = await _repository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (await _questionRepository.IsExistAsync(x => x.TestId == Id))
            {
                foreach (var item in await _questionRepository.GetAllAsync(x => x.TestId == Id))
                {
                    if (await _answerRepository.IsExistAsync(x => x.QuestionId == item.Id))
                        foreach (var subItem in await _answerRepository.GetAllAsync(x => x.QuestionId == item.Id))
                        {
                            await _answerRepository.DeleteAsync(subItem);
                        }

                    await _questionRepository.DeleteAsync(item);
                }
            }

            await _repository.DeleteAsync(query);
            await _repository.SaveAsync();
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

    public async Task<BaseResult> ActiveAsync(int Id)
    {
        Entity.Test.Test query = await _repository.GetAsync(x => x.Id == Id);
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        query.Active();
        await _repository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActive,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> DeActiveAsync(int Id)
    {
        Entity.Test.Test query = await _repository.GetAsync(x => x.Id == Id);
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        query.DeActive();
        await _repository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessDeActive,
            StatusCode = ValidationCode.Success
        };
    }
}