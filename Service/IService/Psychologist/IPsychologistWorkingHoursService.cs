using PC.Dto.Psychologist.PsychologistWorkingHours;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface IPsychologistWorkingHoursService
{
    public Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAllAsync();
    public Task<BaseResult<List<PsychologistWorkingHoursViewModel>>> GetAllAsync(SearchPsychologistWorkingHours f);

    #region CRUD

    public Task<BaseResult<EditPsychologistWorkingHours>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreatePsychologistWorkingHours command);

    public Task<BaseResult> UpdateAsync(EditPsychologistWorkingHours command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}