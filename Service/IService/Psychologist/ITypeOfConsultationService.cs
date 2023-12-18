using PC.Dto.Psychologist.TypeOfConsultation;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface ITypeOfConsultationService
{
    public Task<BaseResult<List<TypeOfConsultationViewModel>>> GetAllAsync();

    #region CRUD

    public Task<BaseResult<EditTypeOfConsultation>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreateTypeOfConsultation command);

    public Task<BaseResult> UpdateAsync(EditTypeOfConsultation command);

    public Task<BaseResult> DeleteAsync(int Id);

    public Task<BaseResult> RestoreDeleteAsync(int Id);

    #endregion
}