using AutoMapper;
using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Service.IRepository.Patient;
using PC.Service.IRepository.Psychologist;
using PC.Service.IRepository.User;
using PC.Service.IService.Psychologist;
using PC.Utility.ReturnFuncResult;
using PC.Utility.UploadFileTools;
using PC.Utility.Validation;

namespace PC.Service.Service.Psychologist;

public class PsychologistService : IPsychologistService
{
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPatientTurnRepository _turnRepository;
    private IMapper _mapper;

    public PsychologistService(IPsychologistRepository psychologistRepository, IPatientRepository patientRepository, IUserRepository userRepository, IPatientTurnRepository turnRepository, IMapper mapper)
    {
        _psychologistRepository = psychologistRepository;
        _patientRepository = patientRepository;
        _userRepository = userRepository;
        _turnRepository = turnRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<PD.Entity.Psychologist.Psychologist> query = await _psychologistRepository.GetAllAsync(include: "PsychologistWorkingDateAndTime,Discount,Order,User.Gender");
            if (!query.Any())
            {
                return new BaseResult<List<PsychologistViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PsychologistViewModel>>> GetAllAsync(SearchPsychologist f)
    {
        try
        {
            List<PD.Entity.Psychologist.Psychologist> query = new List<PD.Entity.Psychologist.Psychologist>();
            if (string.IsNullOrWhiteSpace(f.MedicalLicennseCode) && string.IsNullOrWhiteSpace(f.NationalCode) && f.DateOfBirth == null && f.Age! > 0 && f.Commission! > 0)
            {
                query.AddRange(await _psychologistRepository.GetAllAsync(include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(f.MedicalLicennseCode))
                    query.AddRange(await _psychologistRepository.GetAllAsync(x => x.MedicalLicennseCode.Contains(f.MedicalLicennseCode), include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (!string.IsNullOrWhiteSpace(f.NationalCode))
                    query.AddRange(await _psychologistRepository.GetAllAsync(x => x.NationalCode.Contains(f.NationalCode), include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.DateOfBirth != null)
                    query.AddRange(await _psychologistRepository.GetAllAsync(x => x.DateOfBirth <= f.DateOfBirth, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.Age > 0)
                    query.AddRange(await _psychologistRepository.GetAllAsync(x => x.Age <= f.Age, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.Commission > 0)
                    query.AddRange(await _psychologistRepository.GetAllAsync(x => x.Commission <= f.Commission, include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }

            if (!query.Any())
                return new BaseResult<List<PsychologistViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PsychologistViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologist>> GetAsync(int Id)
    {
        try
        {
            PD.Entity.Psychologist.Psychologist query = await _psychologistRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingDateAndTime,Discount,Order");
            if (query == null)
            {
                return new BaseResult<EditPsychologist>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologist>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologist>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologist>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologist command)
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

            if (await _psychologistRepository.IsExistAsync(x => x.NationalCode == command.NationalCode))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            if (!string.IsNullOrWhiteSpace(command.MedicalLicennseCode))
                if (await _psychologistRepository.IsExistAsync(x => x.MedicalLicennseCode == command.MedicalLicennseCode))
                    return new BaseResult
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.DuplicatedRecordLicennseCode,
                        StatusCode = ValidationCode.BadRequest
                    };

            if (command.ImageLicennse != null)
                if (command.ImageLicennse.IsCheckFile())
                {
                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageLicennse.FileName);
                    command.ImageLicennse.AddFileToServer(imageName, PathExtention.PathImageLicennsePsychologist, null, null);
                    command.EvidencePath = imageName;
                }
                else
                    return new BaseResult() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };

            command.CreatedAt = DateTime.Now.ToString();
            command.IsActive = true;
            await _psychologistRepository.CreateAsync(_mapper.Map<PD.Entity.Psychologist.Psychologist>(command));
            await _psychologistRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPsychologist command)
    {
        try
        {
            if (!await _psychologistRepository.IsExistAsync(x => x.Id == command.Id))
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            PD.Entity.Psychologist.Psychologist query = await _psychologistRepository.GetAsync(x => x.Id == command.Id);
            if (command.ImageLicennse != null)
                if (command.ImageLicennse.IsCheckFile())
                {
                    var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageLicennse.FileName);
                    command.ImageLicennse.AddFileToServer(fileName, /* Create Path */PathExtention.PathImageLicennsePsychologist, null, null, false, command.EvidencePath);
                    command.EvidencePath = fileName;
                }
                else
                    return new BaseResult() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };

            query.Edit(command.Age, command.NationalCode, command.EvidencePath, command.DateOfBirth, command.MedicalLicennseCode);
            await _psychologistRepository.SaveAsync();
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
            PD.Entity.Psychologist.Psychologist query = await _psychologistRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            //if (!string.IsNullOrWhiteSpace(query.EvidencePath))
            //{
            //    if (File.Exists(PathExtention.PathImageLicennsePsychologist + query.EvidencePath))
            //        File.Delete(PathExtention.PathImageLicennsePsychologist + query.EvidencePath);
            //}

            //await _psychologistRepository.DeleteAsync(query);
            query.Delete();
            await _psychologistRepository.SaveAsync();
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

    public async Task<BaseResult<List<PatientTurnViewModel>>> PatientMy(int Id)
    {
        try
        {
            IEnumerable<PD.Entity.Patient.PatientTurn> query = await _turnRepository.GetAllAsync(x => x.PsychologistWorkingDateAndTime.Psychologist.UserId == Id, "Patient.User.Gender");
            if (!query.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success,
                Data = _mapper.Map<List<PatientTurnViewModel>>(query.ToList())
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> ActiveAsync(int Id)
    {
        PD.Entity.Psychologist.Psychologist psychologist = await _psychologistRepository.GetAsync(x => x.Id == Id);
        if (psychologist == null)
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        psychologist.Active();
        await _psychologistRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActive,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> DeActiveAsync(int Id)
    {
        PD.Entity.Psychologist.Psychologist psychologist = await _psychologistRepository.GetAsync(x => x.Id == Id);
        if (psychologist == null)
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        psychologist.DeActive();
        await _psychologistRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessDeActive,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult<IsCheckedUser>> IsChecked(int Id)
    {
        try
        {
            if (!await _userRepository.IsExistAsync(x => x.Id == Id))
                return new BaseResult<IsCheckedUser>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound,
                    Data = new IsCheckedUser
                    {
                        IsPatient = false,
                    }
                };

            if (await _patientRepository.IsExistAsync(x => x.UserId == Id) == true)
                return new BaseResult<IsCheckedUser>()
                {
                    IsSuccess = true,
                    Message = ValidationMessage.SuccessFindPatientSectionPsychologist,
                    StatusCode = ValidationCode.NotFound,
                    Data = new IsCheckedUser
                    {
                        IsPatient = true,
                    }
                };

            return new BaseResult<IsCheckedUser>()
            {
                Message = ValidationMessage.SuccessIsCheckedSectionPsychologist,
                StatusCode = ValidationCode.Success,
                IsSuccess = true,
                Data = new IsCheckedUser
                {
                    IsPatient = false,
                }
            };
        }
        catch (Exception e)
        {
            return new BaseResult<IsCheckedUser>()
            {
                IsSuccess = false,
                // TODO: این باید یه چیز دیگه برگردونه
                Message = ValidationMessage.ErrorUpdate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<MyIncome>>> MyIncome(int Id)
    {
        try
        {
            if (!await _psychologistRepository.IsExistAsync(x => x.Id == Id))
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound,
                };

            IEnumerable<PD.Entity.Patient.PatientTurn> patientTurns = await _turnRepository.GetAllAsync(x => x.PsychologistWorkingDateAndTime.PsychologistId == Id, include: "PsychologistWorkingDateAndTime.Psychologist");
            return new()
            {
                Message = ValidationMessage.SuccessGet,
                StatusCode = ValidationCode.Success,
                IsSuccess = true,
                Data = Mapping.Mapping.ConvertPatientTurnToMyIncomesMapping(patientTurns.ToList())
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