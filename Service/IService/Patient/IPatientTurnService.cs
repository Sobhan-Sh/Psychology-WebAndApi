using PC.Dto.Patient.PatientTurn;
using PC.Dto.Psychologist;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Patient;

public interface IPatientTurnService
{
    public Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync();
    public Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync(SearchPatientTurn f);
    public Task<BaseResult<List<PsychologistViewModel>>> FindPsychologistByPatientIdAsync(int Id);
    public Task<BaseResult<List<PatientTurnViewModel>>> FindPatientByPsychologistIdAsync(int Id);
    public Task<BaseResult<List<PatientTurnViewModel>>> UnvisitedPatients(int Id);

    #region CRUD

    public Task<BaseResult<EditPatientTurn>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreatePatientTurn command);

    public Task<BaseResult<ReturnSetVisitModel>> CreateAsync(SetVisitModel command);

    public Task<BaseResult> UpdateAsync(EditPatientTurn command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion

    public Task<BaseResult> CanseledAsync(int Id);
    public Task<BaseResult> VisitedAsync(int Id);
}