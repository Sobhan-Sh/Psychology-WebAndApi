using Dto.Patient.PatientResponses;
using Utility.ReturnFuncResult;

namespace Service.IService.Patient;

public interface IPatientResponsesService
{
    Task<BaseResult<List<PatientResponsesViewModel>>> GetAllAsync();
}