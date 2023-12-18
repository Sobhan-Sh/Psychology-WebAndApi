using PC.Dto.Patient.PatientFile;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Patient;

public interface IPatientFileService
{
    Task<BaseResult<List<PatientFileViewModel>>> GetAllAsync();

    #region CRD

    Task<BaseResult<PatientFileViewModel>> GetAsync(int Id);
    Task<BaseResult> CreateAsync(CreatePatientFile command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion

    Task<BaseResult> ActiveAsync(int Id);
    Task<BaseResult> DeActiveAsync(int Id);
}