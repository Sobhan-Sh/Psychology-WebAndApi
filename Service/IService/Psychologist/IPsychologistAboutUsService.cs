using PC.Dto.Psychologist.PsychologistAboutUs;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface IPsychologistAboutUsService
{
    #region Get All Data

    Task<BaseResult<List<PsychologistAboutUsViewModel>>> GetAllAsync(SearchPsychologistAboutUs search);

    Task<BaseResult<List<PsychologistAboutUsViewModel>>> GetAllAsync();

    #endregion

    #region CRUD

    Task<BaseResult<EditPsychologistAboutUs>> GetAsync(int Id);

    Task<BaseResult> CreateAsync(CreatePsychologistAboutUs command);

    Task<BaseResult> UpdateAsync(EditPsychologistAboutUs command);

    Task<BaseResult> DeleteAsync(int Id);

    #endregion
}