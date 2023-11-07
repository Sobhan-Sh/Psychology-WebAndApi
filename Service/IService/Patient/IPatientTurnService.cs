using Dto.Patient.PatientTurn;
using Utility.ReturnFuncResult;

namespace Service.IService.Patient;

public interface IPatientTurnService
{
    public Task<BaseResult<PatientTurnViewModel>> GetAllAsync();
    public Task<BaseResult<PatientTurnViewModel>> GetAllAsync(SearchPatientTurn f);

    #region CRUD

    public Task<BaseResult<EditPatientTurn>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreatePatientTurn command);

    public Task<BaseResult> UpdateAsync(EditPatientTurn command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}