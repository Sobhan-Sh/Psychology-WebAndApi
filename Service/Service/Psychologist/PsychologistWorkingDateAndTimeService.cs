using Dto.Psychologist.PsychologistWorkingDateAndTime;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.Service.Psychologist;

public class PsychologistWorkingDateAndTimeService : IPsychologistWorkingDateAndTimeService
{
    private readonly IPsychologistWorkingDateAndTimeRepository _dateAndTimeRepository;

    public PsychologistWorkingDateAndTimeService(IPsychologistWorkingDateAndTimeRepository dateAndTimeRepository)
    {
        _dateAndTimeRepository = dateAndTimeRepository;
    }

    public async Task<BaseResult<PsychologistWorkingDateAndTimeViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditPsychologistWorkingDateAndTime>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistWorkingDateAndTime command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditPsychologistWorkingDateAndTime command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}