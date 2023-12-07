using Dto.Psychologist.PsychologistTypeOfConsultation;
using Utility.ReturnFuncResult;

namespace Service.IService.Psychologist;

public interface IPsychologistTypeOfConsultationService
{
    public Task<BaseResult<List<PsychologistTypeOfConsultationViewModel>>> GetAllAsync(SearchPsychologistTypeOfConsultation f);
    public Task<BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>>> ReturnNewModelInPageVisitGetAllAsync(SearchPsychologistTypeOfConsultation f);

    #region CRUD

    public Task<BaseResult<EditPsychologistTypeOfConsultation>> GetAsync(int Id);
    public Task<BaseResult> CreateAsync(CreatePsychologistTypeOfConsultation command);
    public Task<BaseResult> UpdateAsync(EditPsychologistTypeOfConsultation command);
    public Task<BaseResult> DeleteAsync(int Id);
    public Task<BaseResult<int>> ReturnDeleteAsync(int Id);

    #endregion
}