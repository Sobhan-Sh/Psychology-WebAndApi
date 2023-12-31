﻿using AutoMapper;
using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Service.IRepository.Patient;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Utility.DateConvertor;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.Patient;
using PD.Entity.Psychologist;

namespace PC.Service.Service.Psychologist;

public class PsychologistWorkingDateAndTimeService : IPsychologistWorkingDateAndTimeService
{
    private readonly IPsychologistWorkingDateAndTimeRepository _dateAndTimeRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IPatientTurnRepository _turnRepository;
    private IMapper _mapper;

    public PsychologistWorkingDateAndTimeService(IPsychologistWorkingDateAndTimeRepository dateAndTimeRepository, IPsychologistRepository psychologistRepository, IPatientTurnRepository turnRepository, IMapper mapper)
    {
        _dateAndTimeRepository = dateAndTimeRepository;
        _psychologistRepository = psychologistRepository;
        _turnRepository = turnRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<PsychologistWorkingDateAndTime> query = await _dateAndTimeRepository.GetAllAsync(include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
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
            List<PsychologistWorkingDateAndTime> query = new List<PsychologistWorkingDateAndTime>();
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
            PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
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
            PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.PsychologistId == Id, include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
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
            await _dateAndTimeRepository.CreateAsync(_mapper.Map<PsychologistWorkingDateAndTime>(command));
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
            PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == command.Id);
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
            PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id);
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
            PsychologistWorkingDateAndTime query = await _dateAndTimeRepository.GetAsync(x => x.Id == Id);
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

    public async Task<BaseResult<List<CheckDateVisit>>> CheckDateVisit(int Id, DateTime DateVisit)
    {
        try
        {
            if (Id < 1 || DateVisit == null)
                return new BaseResult<List<CheckDateVisit>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.NotFound
                };

            PD.Entity.Psychologist.Psychologist psychologist = await _psychologistRepository.GetAsync(x => x.Id == Id);
            if (psychologist == null)
                return new BaseResult<List<CheckDateVisit>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };

            string ResultDateVisitMessage = null;
            IEnumerable<PsychologistWorkingDateAndTime> dateVisit = await _dateAndTimeRepository.GetAllAsync(x => x.PsychologistId == Id && x.PsychologistWorkingDays.DayEn == DateVisit.DayOfWeek.ToString(), include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
            if (dateVisit.Count() < 1)
            {
                int day = 1;
                while (!dateVisit.Any())
                {
                    //TODO: چک بشه تاریخ که اگر یکی اضافه شد برای بار دوم دوتا اضافه نشه و مقدار بشه 3 و تاریخ 3 روز بره جلو
                    dateVisit = await _dateAndTimeRepository.GetAllAsync(x => x.PsychologistId == Id && x.PsychologistWorkingDays.DayEn == DateVisit.AddDays(day).DayOfWeek.ToString(), include: "PsychologistWorkingHours,PsychologistWorkingDays,Psychologist");
                    string dayName = dateVisit.Any()
                        ? dateVisit.FirstOrDefault().PsychologistWorkingDays.Day
                        : DateTimeConvertor.ConvertDayEnglishToPersian(DateVisit.AddDays(day).DayOfWeek.ToString());

                    ResultDateVisitMessage = $"دکتر در این روز ویزیت نمی کند.شما می توانید{dayName} یعنی {day} روز بعد از تاریخ انتخاب شده ساعت ویزیت خود را مشخص کنید";
                    day++;
                    if (day == 7 && !dateVisit.Any())
                        return new BaseResult<List<CheckDateVisit>>
                        {
                            IsSuccess = false,
                            Message = ValidationMessage.NoFoundGet,
                            StatusCode = ValidationCode.NotFound
                        };

                }
            }

            List<PatientTurn> patientTurnsModel = new();
            foreach (var psychologistWorkingDateAndTime in dateVisit)
            {
                PatientTurn patientTurn = await _turnRepository.GetAsync(x => x.PsychologistWorkingDateAndTimeId == psychologistWorkingDateAndTime.Id);
                if (patientTurn != null)
                    patientTurnsModel.Add(patientTurn);
            }
            return new BaseResult<List<CheckDateVisit>>
            {
                IsSuccess = true,
                Message = !string.IsNullOrWhiteSpace(ResultDateVisitMessage) ? ResultDateVisitMessage : ValidationMessage.SuccessGet,
                Data = Mapping.Mapping.ConvertPsychologistWorkingDateAndTimeToCheckDateVisitMapping(dateVisit.ToList(), patientTurnsModel),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<CheckDateVisit>>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}