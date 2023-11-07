using Dto.Patient.PatientTurn;
using Service.IRepository.Patient;
using Service.IService.Patient;
using Utility.ReturnFuncResult;

namespace Service.Service.Patient;

public class PatientTurnService : IPatientTurnService
{
    private readonly IPatientTurnRepository _patientTurnRepository;

    public PatientTurnService(IPatientTurnRepository patientTurnRepository)
    {
        _patientTurnRepository = patientTurnRepository;
    }

    public async Task<BaseResult<PatientTurnViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<PatientTurnViewModel>> GetAllAsync(SearchPatientTurn f)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditPatientTurn>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreatePatientTurn command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditPatientTurn command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}