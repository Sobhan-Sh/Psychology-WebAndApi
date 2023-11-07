using Dto.Psychologist.TypeOfConsultation;
using Utility.ReturnFuncResult;

namespace Service.IService.Psychologist;

public interface ITypeOfConsultationService
{
    public Task<BaseResult<TypeOfConsultationViewModel>> GetAllAsync();

    #region CRUD

    public Task<BaseResult<EditTypeOfConsultation>> GetAsync(int Id);

    public Task<BaseResult> CreateAsync(CreateTypeOfConsultation command);

    public Task<BaseResult> UpdateAsync(EditTypeOfConsultation command);

    public Task<BaseResult> DeleteAsync(int Id);

    #endregion
}