using Dto.Patient;
using Utility.ReturnFuncResult;

namespace Service.IService.Patient;

public interface IPatientService
{
    #region GetAll Data

    Task<BaseResult<List<PatientViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<PatientViewModel>> GetAsync(int Id);
    Task<BaseResult<PatientViewModel>> GetAsync(SearchPatientViewModel fil);

    Task<BaseResult> CreateAsync(CreatePatient command);

    Task<BaseResult> UpdateAsync(EditPatient command);

    Task<BaseResult> DeleteAsync(int Id);

    #endregion
}