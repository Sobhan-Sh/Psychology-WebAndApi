using PC.Dto.Psychologist.PsychologistWorkingDateAndTime;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface IPsychologistWorkingDateAndTimeService
{
    public Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAllAsync();
    public Task<BaseResult<List<PsychologistWorkingDateAndTimeViewModel>>> GetAllAsync(SearchPsychologistWorkingDateAndTime command);

    #region CRUD

    public Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetAsync(int Id);
    public Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetByPsychologistId(int Id);
    public Task<BaseResult> CreateAsync(CreatePsychologistWorkingDateAndTime command);
    public Task<BaseResult> UpdateAsync(EditPsychologistWorkingDateAndTime command);
    public Task<BaseResult> DeleteAsync(int Id);
    public Task<BaseResult<int>> ReturnIdDeleteAsync(int Id);
    public Task<BaseResult<List<CheckDateVisit>>> CheckDateVisit(int Id, DateTime DateVisit);

    #endregion
}