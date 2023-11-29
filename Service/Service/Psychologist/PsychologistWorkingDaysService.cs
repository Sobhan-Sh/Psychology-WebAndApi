using AutoMapper;
using Dto.Psychologist.PsychologistWorkingDays;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Psychologist;

public class PsychologistWorkingDaysService : IPsychologistWorkingDaysService
{
    private readonly IPsychologistWorkingDaysRepository _psychologistWorkingDays;
    private IMapper _mapper;

    public PsychologistWorkingDaysService(IPsychologistWorkingDaysRepository psychologistWorkingDays, IMapper mapper)
    {
        _psychologistWorkingDays = psychologistWorkingDays;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistWorkingDaysViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Psychologist.PsychologistWorkingDays> query = await _psychologistWorkingDays.GetAllAsync();
            if (!query.Any())
            {
                return new BaseResult<List<PsychologistWorkingDaysViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistWorkingDaysViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistWorkingDaysViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistWorkingDaysViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologistWorkingDays>> GetAsync(int Id)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDays query = await _psychologistWorkingDays.GetAsync(x => x.Id == Id);
            if (query == null)
            {
                return new BaseResult<EditPsychologistWorkingDays>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologistWorkingDays>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistWorkingDays>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologistWorkingDays>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingDays command)
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

            if (await _psychologistWorkingDays.IsExistAsync(x => x.Day == command.Day))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            await _psychologistWorkingDays.CreateAsync(_mapper.Map<Entity.Psychologist.PsychologistWorkingDays>(command));
            await _psychologistWorkingDays.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingDays command)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDays query = await _psychologistWorkingDays.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Day = command.Day;
            query.UpdatedAt = DateTime.Now;
            await _psychologistWorkingDays.SaveAsync();
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
            Entity.Psychologist.PsychologistWorkingDays query = await _psychologistWorkingDays.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _psychologistWorkingDays.DeleteAsync(query);
            await _psychologistWorkingDays.SaveAsync();
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