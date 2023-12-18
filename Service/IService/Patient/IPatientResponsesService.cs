using PC.Dto.Patient.PatientResponses;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Patient;

public interface IPatientResponsesService
{
    Task<BaseResult<List<PatientResponsesViewModel>>> GetAllAsync();
}