using AutoMapper;
using PC.Dto.Patient.PatientResponses;
using PC.Service.IRepository.Patient;
using PC.Service.IService.Patient;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.Patient;

namespace PC.Service.Service.Patient;

public class PatientResponsesService : IPatientResponsesService
{
    private readonly IPatientResponsRepository _patientResponsRepository;
    private IMapper _mapper;

    public PatientResponsesService(IPatientResponsRepository patientResponsRepository, IMapper mapper)
    {
        _patientResponsRepository = patientResponsRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientResponsesViewModel>>> GetAllAsync()
    {
        IEnumerable<PatientResponses> query = await _patientResponsRepository.GetAllAsync();
        if (!query.Any())
            return new BaseResult<List<PatientResponsesViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.Vacant,
                StatusCode = ValidationCode.Success
            };

        return new BaseResult<List<PatientResponsesViewModel>>
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessGetAll,
            Data = _mapper.Map<List<PatientResponsesViewModel>>(query),
            StatusCode = ValidationCode.Success
        };
    }
}