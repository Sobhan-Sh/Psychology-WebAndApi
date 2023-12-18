using AutoMapper;
using PC.Dto.Patient;
using PC.Service.IRepository.Patient;
using PC.Service.IService.Patient;
using PC.Utility.ReturnFuncResult;
using PC.Utility.UploadFileTools;
using PC.Utility.Validation;
using PD.Entity.Patient;

namespace PC.Service.Service.Patient;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientTurnRepository _patientTurnRepository;
    private IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IPatientTurnRepository patientTurnRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _patientTurnRepository = patientTurnRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientViewModel>>> GetAllAsync()
    {
        IEnumerable<PD.Entity.Patient.Patient> query = await _patientRepository.GetAllAsync();
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

    public async Task<BaseResult<List<ListPatientViewModel>>> GetListPatientAsync()
    {
        try
        {
            IEnumerable<PD.Entity.Patient.Patient> query = await _patientRepository.GetAllAsync(include: "User.Gender");
            if (!query.Any())
            {
                return new()
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            List<PD.Entity.Patient.PatientTurn> patientTurns = new();
            foreach (var patient in query)
            {
                PatientTurn patientTurn = await _patientTurnRepository.GetAsync(x => x.PatientId == patient.Id, include: "PsychologistWorkingDateAndTime.Psychologist.User");
                if (patientTurn != null)
                    patientTurns.Add(patientTurn);
            }

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = Mapping.Mapping.ConvertPatientToListPatientViewModelMapping(query.ToList(), patientTurns),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<PatientViewModel>> GetAsync(int Id)
    {
        PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id, include: "User.Gender");
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
        PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.NationalCode == fil.NationalCode);
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

            await _patientRepository.CreateAsync(_mapper.Map<PD.Entity.Patient.Patient>(command));
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
            PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == command.Id);
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
            PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Delete();
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

    public async Task<BaseResult> Visited(int Id)
    {
        PatientTurn query = await _patientTurnRepository.GetAsync(x => x.PatientId == Id, include: "Patient");
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        if (!query.Patient.IsPatient)
            query.Patient.Delete();

        query.Visited();
        await _patientRepository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessVisited,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> ChangeToPatient(int Id)
    {
        PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id);
        if (query == null)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.NoFoundGet,
                StatusCode = ValidationCode.NotFound
            };
        }

        query.IsPatientTrue();
        await _patientRepository.SaveAsync();
        return new()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessChangeToPatient,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> RestorPatient(int Id)
    {
        PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == Id);
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        query.Restor();
        await _patientRepository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessDelete,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> UpdateAsync(PatientViewModel command)
    {
        try
        {
            PD.Entity.Patient.Patient query = await _patientRepository.GetAsync(x => x.Id == command.Id, include: "User.Role");
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (command.UserViewModel.ImageUser != null)
            {
                if (command.UserViewModel.ImageUser.IsCheckFile())
                {
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.UserViewModel.ImageUser.FileName);
                    command.UserViewModel.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, 100, 100, false, command.UserViewModel.Avatar);
                    command.UserViewModel.Avatar = imageName;
                }
                else
                {
                    return new BaseResult() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };
                }
            }

            query.User.Edit(command.UserViewModel.FName, command.UserViewModel.LName, command.UserViewModel.Address, !string.IsNullOrWhiteSpace(command.UserViewModel.Avatar) ? command.UserViewModel.Avatar : "", query.User.RoleID, command.UserViewModel.GenderViewModel.Id);
            query.Edit(command.NationalCode, command.Age);
            await _patientRepository.SaveAsync();
            return new()
            {
                Message = ValidationMessage.SuccessUpdate,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorUpdate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}