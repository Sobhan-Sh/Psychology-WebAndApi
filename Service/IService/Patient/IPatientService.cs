using PC.Dto.Patient;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Patient;

public interface IPatientService
{
    #region GetAll Data

    Task<BaseResult<List<PatientViewModel>>> GetAllAsync();

    Task<BaseResult<List<ListPatientViewModel>>> GetListPatientAsync();

    #endregion

    #region CRUD

    Task<BaseResult<PatientViewModel>> GetAsync(int Id);

    Task<BaseResult<PatientViewModel>> GetAsync(SearchPatientViewModel fil);

    Task<BaseResult> CreateAsync(CreatePatient command);

    Task<BaseResult> UpdateAsync(EditPatient command);

    Task<BaseResult> UpdateAsync(PatientViewModel command);

    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    Task<BaseResult> Visited(int Id);

    Task<BaseResult> ChangeToPatient(int Id);

    Task<BaseResult> RestorPatient(int Id);
}