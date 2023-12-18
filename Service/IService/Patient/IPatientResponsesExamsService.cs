using PC.Dto.Patient.PatientResponsesExams;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Patient;

public interface IPatientResponsesExamsService
{
    public Task<BaseResult> CreateAsync(CreatePatientResponsesExams command);
}