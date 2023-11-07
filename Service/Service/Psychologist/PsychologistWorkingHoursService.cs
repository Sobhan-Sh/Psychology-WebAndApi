using Dto.Psychologist.PsychologistWorkingHours;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.Service.Psychologist;

public class PsychologistWorkingHoursService : IPsychologistWorkingHoursService
{
    private readonly IPsychologistWorkingHoursRepository _psychologistWorkingHours;

    public PsychologistWorkingHoursService(IPsychologistWorkingHoursRepository psychologistWorkingHours)
    {
        _psychologistWorkingHours = psychologistWorkingHours;
    }

    public async Task<BaseResult<PsychologistWorkingHoursViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<PsychologistWorkingHoursViewModel>> GetAllAsync(SearchPsychologistWorkingHours f)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditPsychologistWorkingHours>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingHours command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingHours command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}