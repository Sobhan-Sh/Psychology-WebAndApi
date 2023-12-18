using PC.Dto.Psychologist.PsychologistWorkingDays;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface IPsychologistWorkingDaysService
{
    public Task<BaseResult<List<PsychologistWorkingDaysViewModel>>> GetAllAsync();

    #region CRUD

    public Task<BaseResult<EditPsychologistWorkingDays>> GetAsync(int Id);
    public Task<BaseResult> CreateAsync(CreatePsychologistWorkingDays command);
    public Task<BaseResult> UpdateAsync(EditPsychologistWorkingDays command);
    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}