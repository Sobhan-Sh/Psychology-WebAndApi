using AutoMapper;
using Dto.Patient.PatientResponses;
using Entity.Patient;
using Service.IRepository.Patient;
using Service.IService.Patient;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Patient;

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