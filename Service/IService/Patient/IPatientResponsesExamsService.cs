using Dto.Patient.PatientResponsesExams;
using Utility.ReturnFuncResult;

namespace Service.IService.Patient;

public interface IPatientResponsesExamsService
{
    public Task<BaseResult> CreateAsync(CreatePatientResponsesExams command);
}