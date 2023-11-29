using AutoMapper;
using Dto.Psychologist.PsychologistWorkingHours;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Psychologist;

public class PsychologistWorkingHoursService : IPsychologistWorkingHoursService
{
    private readonly IPsychologistWorkingHoursRepository _psychologistWorkingHours;
    private IMapper _mapper;

    public PsychologistWorkingHoursService(IPsychologistWorkingHoursRepository psychologistWorkingHours, IMapper mapper)
    {
        _psychologistWorkingHours = psychologistWorkingHours;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Psychologist.PsychologistWorkingHours> query = await _psychologistWorkingHours.GetAllAsync();
            if (!query.Any())
            {
                return new BaseResult<List<PsychologistWorkingHoursViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistWorkingHoursViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistWorkingHoursViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistWorkingHoursViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAllAsync(SearchPsychologistWorkingHours f)
    {
        try
        {
            List<Entity.Psychologist.PsychologistWorkingHours> query = new List<Entity.Psychologist.PsychologistWorkingHours>();
            if (f.EndTime == null && f.StartTime == null)
            {
                query.AddRange(await _psychologistWorkingHours.GetAllAsync());
            }
            else
            {
                if (f.EndTime != null)
                    query.AddRange(await _psychologistWorkingHours.GetAllAsync(x => x.EndTime <= f.EndTime));

                if (f.StartTime != null)
                    query.AddRange(await _psychologistWorkingHours.GetAllAsync(x => x.StartTime >= f.StartTime));
            }

            if (!query.Any())
                return new BaseResult<List<PsychologistWorkingHoursViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PsychologistWorkingHoursViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PsychologistWorkingHoursViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistWorkingHoursViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologistWorkingHours>> GetAsync(int Id)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingHours query = await _psychologistWorkingHours.GetAsync(x => x.Id == Id);
            if (query == null)
            {
                return new BaseResult<EditPsychologistWorkingHours>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologistWorkingHours>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistWorkingHours>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologistWorkingHours>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingHours command)
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

            await _psychologistWorkingHours.CreateAsync(_mapper.Map<Entity.Psychologist.PsychologistWorkingHours>(command));
            await _psychologistWorkingHours.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingHours command)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingHours query = await _psychologistWorkingHours.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.StartTime, command.EndTime);
            await _psychologistWorkingHours.SaveAsync();
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
            Entity.Psychologist.PsychologistWorkingHours query = await _psychologistWorkingHours.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _psychologistWorkingHours.DeleteAsync(query);
            await _psychologistWorkingHours.SaveAsync();
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