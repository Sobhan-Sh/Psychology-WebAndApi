using Dto.Psychologist;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.Service.Psychologist;

public class PsychologistService : IPsychologistService
{
    private readonly IPsychologistRepository _psychologistRepository;

    public PsychologistService(IPsychologistRepository psychologistRepository)
    {
        _psychologistRepository = psychologistRepository;
    }

    public async Task<BaseResult<PsychologistViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<PsychologistViewModel>> GetAllAsync(SearchPsychologist f)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditPsychologist>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologist command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditPsychologist command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> ActiveAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeActiveAsync(int Id)
    {
        throw new NotImplementedException();
    }
}