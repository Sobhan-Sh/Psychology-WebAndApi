using Dto.Psychologist.PsychologistWorkingDays;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.Service.Psychologist;

public class PsychologistWorkingDaysService : IPsychologistWorkingDaysService
{
    private readonly IPsychologistWorkingDaysRepository _psychologistWorkingDays;

    public PsychologistWorkingDaysService(IPsychologistWorkingDaysRepository psychologistWorkingDays)
    {
        _psychologistWorkingDays = psychologistWorkingDays;
    }

    public async Task<BaseResult<PsychologistWorkingDaysViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditPsychologistWorkingDays>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingDays command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingDays command)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}