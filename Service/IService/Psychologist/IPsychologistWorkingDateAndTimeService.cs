using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Utility.ReturnFuncResult;

namespace Service.IService.Psychologist;

public interface IPsychologistWorkingDateAndTimeService
{
    public Task<BaseResult<PsychologistWorkingDateAndTimeViewModel>> GetAllAsync();

    #region CRUD

    public Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetAsync(int Id);
    public Task<BaseResult> CreateAsync(CreatePsychologistWorkingDateAndTime command);
    public Task<BaseResult> UpdateAsync(EditPsychologistWorkingDateAndTime command);
    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}