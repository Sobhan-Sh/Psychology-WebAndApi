﻿using Dto.Psychologist;
using Utility.ReturnFuncResult;

namespace Service.IService.Psychologist;

public interface IPsychologistService
{
    #region Get All

    public Task<BaseResult<List<PsychologistViewModel>>> GetAllAsync();
    public Task<BaseResult<List<PsychologistViewModel>>> GetAllAsync(SearchPsychologist f);

    #endregion

    #region CRUD

    public Task<BaseResult<EditPsychologist>> GetAsync(int Id);
    public Task<BaseResult> CreateAsync(CreatePsychologist command);
    public Task<BaseResult> UpdateAsync(EditPsychologist command);
    public Task<BaseResult> DeleteAsync(int Id);

    #endregion

    public Task<BaseResult> ActiveAsync(int Id);
    public Task<BaseResult> DeActiveAsync(int Id);
    public Task<BaseResult<IsCheckedUser>> IsChecked(int Id);
}