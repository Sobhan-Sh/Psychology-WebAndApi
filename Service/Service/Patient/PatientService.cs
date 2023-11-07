using AutoMapper;
using Dto.Patient;
using Service.IRepository.Patient;
using Service.IService.Patient;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Patient;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientViewModel>>> GetAllAsync()
    {
        IEnumerable<Entity.Patient.Patient> query = await _patientRepository.GetAllAsync();
        if (!query.Any())
        {
            return new BaseResult<List<PatientViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.Vacant,
                StatusCode = ValidationCode.Success
            };
        }

        return new BaseResult<List<PatientViewModel>>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGetAllSearch(query.Count()),
            Data = _mapper.Map<List<PatientViewModel>>(query),
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult<PatientViewModel>> GetAsync(int Id)
    {
        Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id);
        if (query == null)
        {
            return new BaseResult<PatientViewModel>
            {
                IsSuccess = false,
                Message = ValidationMessage.NoFoundGet,
                StatusCode = ValidationCode.NotFound
            };
        }

        return new BaseResult<PatientViewModel>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGet,
            Data = _mapper.Map<PatientViewModel>(query),
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult<PatientViewModel>> GetAsync(SearchPatientViewModel fil)
    {
        Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.NationalCode == fil.NationalCode);
        if (query == null)
        {
            return new BaseResult<PatientViewModel>
            {
                IsSuccess = true,
                Message = ValidationMessage.Vacant,
                StatusCode = ValidationCode.Success
            };
        }

        return new BaseResult<PatientViewModel>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGet,
            Data = _mapper.Map<PatientViewModel>(query),
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> CreateAsync(CreatePatient command)
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

            if (await _patientRepository.IsExistAsync(x => x.NationalCode == command.NationalCode))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            await _patientRepository.CreateAsync(_mapper.Map<Entity.Patient.Patient>(command));
            await _patientRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPatient command)
    {
        try
        {
            Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.NationalCode, command.Age);
            query.UpdatedAt = DateTime.Now;
            query.IsActive = true;
            await _patientRepository.SaveAsync();
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
            Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _patientRepository.DeleteAsync(query);
            await _patientRepository.SaveAsync();
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