using AutoMapper;
using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Psychologist;

public class PsychologistWorkingDateAndTimeService : IPsychologistWorkingDateAndTimeService
{
    private readonly IPsychologistWorkingDateAndTimeRepository _dateAndTimeRepository;
    private IMapper _mapper;

    public PsychologistWorkingDateAndTimeService(IPsychologistWorkingDateAndTimeRepository dateAndTimeRepository, IMapper mapper)
    {
        _dateAndTimeRepository = dateAndTimeRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Psychologist.PsychologistWorkingDateAndTime> query = await _dateAndTimeRepository.GetAllAsync(include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
            if (!query.Any())
            {
                return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistWorkingDateAndTimeViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAllAsync(SearchPsychologistWorkingDateAndTime command)
    {
        try
        {
            List<Entity.Psychologist.PsychologistWorkingDateAndTime> query = new List<Entity.Psychologist.PsychologistWorkingDateAndTime>();
            if (command.PsychologistId == 0 && command.PsychologistWorkingDaysId == 0 && command.PsychologistWorkingHoursId == 0)
            {
                return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequiredSearch,
                    StatusCode = ValidationCode.BadRequest
                };
            }
            else
            {
                if (command.PsychologistId > 0)
                    query.AddRange(await _dateAndTimeRepository.GetAllAsync(x => x.PsychologistId == command.PsychologistId, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist"));

                if (command.PsychologistWorkingDaysId > 0)
                    query.AddRange(await _dateAndTimeRepository.GetAllAsync(x => x.PsychologistWorkingDaysId == command.PsychologistWorkingDaysId, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist"));

                if (command.PsychologistWorkingHoursId > 0)
                    query.AddRange(await _dateAndTimeRepository.GetAllAsync(x => x.PsychologistWorkingHoursId == command.PsychologistWorkingHoursId, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist"));
            }

            if (!query.Any())
            {
                return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PsychologistWorkingDateAndTimeViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetAsync(int Id)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
            if (query == null)
            {
                return new BaseResult<EditPsychologistWorkingDateAndTime>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologistWorkingDateAndTime>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistWorkingDateAndTime>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologistWorkingDateAndTime>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetByPsychologistId(int Id)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.PsychologistId == Id, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
            if (query == null)
            {
                return new BaseResult<EditPsychologistWorkingDateAndTime>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologistWorkingDateAndTime>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistWorkingDateAndTime>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologistWorkingDateAndTime>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingDateAndTime command)
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

            command.IsActive = true;
            await _dateAndTimeRepository.CreateAsync(_mapper.Map<Entity.Psychologist.PsychologistWorkingDateAndTime>(command));
            await _dateAndTimeRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingDateAndTime command)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.PsychologistWorkingHoursId, command.PsychologistWorkingDaysId);
            await _dateAndTimeRepository.SaveAsync();
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
            Entity.Psychologist.PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _dateAndTimeRepository.DeleteAsync(query);
            await _dateAndTimeRepository.SaveAsync();
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

    public async Task<BaseResult<int>> ReturnIdDeleteAsync(int Id)
    {
        try
        {
            Entity.Psychologist.PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult<int>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _dateAndTimeRepository.DeleteAsync(query);
            await _dateAndTimeRepository.SaveAsync();
            return new BaseResult<int>()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success,
                Data = query.PsychologistId
            };
        }
        catch (Exception e)
        {
            return new BaseResult<int>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}