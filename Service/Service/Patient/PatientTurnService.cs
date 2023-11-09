﻿using AutoMapper;
using Dto.Patient.PatientTurn;
using Entity.Psychologist;
using Service.IRepository.Patient;
using Service.IRepository.Psychologist;
using Service.IService.Patient;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Patient;

public class PatientTurnService : IPatientTurnService
{
    private readonly IPatientTurnRepository _patientTurnRepository;
    private readonly ITypeOfConsultationRepository _typeOfConsultationRepository;
    private IMapper _mapper;

    public PatientTurnService(IPatientTurnRepository patientTurnRepository, ITypeOfConsultationRepository typeOfConsultationRepository, IMapper mapper)
    {
        _patientTurnRepository = patientTurnRepository;
        _typeOfConsultationRepository = typeOfConsultationRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Patient.PatientTurn> query = await _patientTurnRepository.GetAllAsync(include: "Patient,Order,TypeOfConsultation,PsychologistWorkingDateAndTime");
            if (!query.Any())
            {
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PatientTurnViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync(SearchPatientTurn f)
    {
        try
        {
            List<Entity.Patient.PatientTurn> query = new List<Entity.Patient.PatientTurn>();
            if (f.ConsultationDay == null && f.Price < 1)
            {
                query.AddRange(await _patientTurnRepository.GetAllAsync(include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }
            else
            {
                if (f.Price > 0)
                    query.AddRange(await _patientTurnRepository.GetAllAsync(x => x.Price >= f.Price, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.ConsultationDay != null)
                    query.AddRange(await _patientTurnRepository.GetAllAsync(x => x.ConsultationDay >= f.ConsultationDay, include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }

            if (!query.Any())
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PatientTurnViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPatientTurn>> GetAsync(int Id)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingDateAndTime,Discount,Order");
            if (query == null)
            {
                return new BaseResult<EditPatientTurn>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPatientTurn>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPatientTurn>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPatientTurn>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePatientTurn command)
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

            //TODO : ما اینجا باید محاسبه کنیم قیمت مشاوره رو بر اساس ساعت
            TypeOfConsultation typeOfConsultation = await _typeOfConsultationRepository.GetAsync(x => x.Id == command.TypeOfConsultationId);
            command.Price = 120000 + typeOfConsultation.Price;
            await _patientTurnRepository.CreateAsync(_mapper.Map<Entity.Patient.PatientTurn>(command));
            await _patientTurnRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPatientTurn command)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.Price, command.ConsultationDay, command.TypeOfConsultationId, command.PsychologistWorkingDateAndTimeId);
            await _patientTurnRepository.SaveAsync();
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
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _patientTurnRepository.DeleteAsync(query);
            await _patientTurnRepository.SaveAsync();
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