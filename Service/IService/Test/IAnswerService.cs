﻿using Dto.Test.Answer;
using Utility.ReturnFuncResult;

namespace Service.IService.Test;

public interface IAnswerService
{
    #region GetAll Data

    Task<BaseResult<List<AnswerViewModel>>> GetAllAsync(SearchAnswerViewModel search);
    Task<BaseResult<List<AnswerViewModel>>> GetAllAsync();

    #endregion

    #region CRD

    Task<BaseResult<EditAnswer>> GetAsync(int Id);
    Task<BaseResult> CreateAsync(CreateAnswer command);
    Task<BaseResult> DeleteAsync(int Id);

    #endregion
}