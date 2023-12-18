using AutoMapper;
using PC.Dto.Patient.PatientFile;
using PC.Service.IRepository.Patient;
using PC.Service.IService.Patient;
using PC.Utility.ReturnFuncResult;
using PC.Utility.UploadFileTools;
using PC.Utility.Validation;
using PD.Entity.Patient;

namespace PC.Service.Service.Patient;
public class PatientFileService : IPatientFileService
{
    private readonly IPatientFileRepository _patientFileRepository;
    private readonly IPatientRepository _patientRepository;
    private IMapper _mapper;

    public PatientFileService(IPatientFileRepository patientFileRepository, IPatientRepository patientRepository, IMapper mapper)
    {
        _patientFileRepository = patientFileRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientFileViewModel>>> GetAllAsync()
    {
        IEnumerable<PatientFile> query = await _patientFileRepository.GetAllAsync();
        if (!query.Any())
            return new BaseResult<List<PatientFileViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.Vacant,
                StatusCode = ValidationCode.Success
            };

        return new BaseResult<List<PatientFileViewModel>>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGetAll,
            Data = _mapper.Map<List<PatientFileViewModel>>(query),
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult<PatientFileViewModel>> GetAsync(int Id)
    {
        PatientFile query = await _patientFileRepository.GetAsync(x => x.Id == Id);
        if (query == null)
        {
            return new BaseResult<PatientFileViewModel>
            {
                IsSuccess = false,
                Message = ValidationMessage.NoFoundGet,
                StatusCode = ValidationCode.NotFound
            };
        }

        return new BaseResult<PatientFileViewModel>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGet,
            Data = _mapper.Map<PatientFileViewModel>(query),
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> CreateAsync(CreatePatientFile command)
    {
        try
        {
            if (command.File.IsCheckFile())
            {
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.File.FileName);
                // query patient
                var patient = await _patientRepository.GetAsync(x => x.Id == command.PatientId, include: "User");
                // create path
                string pathFilePatient = PathExtention.PatientFile + "/" + patient.User.FullName() + "/";
                // check && upload file
                command.File.AddFileToServer(fileName, pathFilePatient, null, null);
                command.FilePath = fileName;
            }

            await _patientFileRepository.CreateAsync(_mapper.Map<PatientFile>(command));
            await _patientFileRepository.SaveAsync();
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

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        try
        {
            PatientFile query = await _patientFileRepository.GetAsync(x => x.Id == Id);
            PD.Entity.Patient.Patient user = await _patientRepository.GetAsync(x => x.Id == query.PatientId, "User");
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (!string.IsNullOrWhiteSpace(query.FilePath))
            {
                if (File.Exists(PathExtention.PatientFile + $"/{user.User.FullName()}/" + query.FilePath))
                    File.Delete(PathExtention.PatientFile + $"/{user.User.FullName()}/" + query.FilePath);
            }

            await _patientFileRepository.DeleteAsync(query);
            await _patientFileRepository.SaveAsync();
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
        PatientFile query = await _patientFileRepository.GetAsync(x => x.Id == Id);
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        query.Active();
        await _patientFileRepository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActiveFile,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> DeActiveAsync(int Id)
    {
        PatientFile query = await _patientFileRepository.GetAsync(x => x.Id == Id);
        if (query == null)
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        query.DeActive();
        await _patientFileRepository.SaveAsync();
        return new BaseResult()
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessDeActiveFile,
            StatusCode = ValidationCode.Success
        };
    }
}