using Dto.Psychologist.TypeOfConsultation;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.Service.Psychologist;

public class TypeOfConsultationService : ITypeOfConsultationService
{
    private readonly ITypeOfConsultationRepository _consultationRepository;

    public TypeOfConsultationService(ITypeOfConsultationRepository consultationRepository)
    {
        _consultationRepository = consultationRepository;
    }

    public async Task<BaseResult<TypeOfConsultationViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<EditTypeOfConsultation>> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> CreateAsync(CreateTypeOfConsultation command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> UpdateAsync(EditTypeOfConsultation command)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }
}