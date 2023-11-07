using Dto.Psychologist.PsychologistWorkingHours;
using Utility.ReturnFuncResult;

namespace Service.IService.Psychologist;

public interface IPsychologistWorkingHoursService
{
    public Task<BaseResult<PsychologistWorkingHoursViewModel>> GetAllAsync();
    public Task<BaseResult<PsychologistWorkingHoursViewModel>> GetAllAsync(SearchPsychologistWorkingHours f);

    #region CRUD

    public Task<BaseResult<EditPsychologistWorkingHours>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreatePsychologistWorkingHours command);

    public Task<BaseResult> UpdateAsync(EditPsychologistWorkingHours command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}