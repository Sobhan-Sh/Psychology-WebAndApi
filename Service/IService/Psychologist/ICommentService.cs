﻿using Microsoft.AspNetCore.Http;
using PC.Dto.Psychologist.Comment;
using PC.Utility.ReturnFuncResult;

namespace PC.Service.IService.Psychologist;

public interface ICommentService
{
    Task<BaseResult<List<CommentViewModel>>> GetAllAsync(SearchComment search);
    Task<BaseResult<PatientCommentViewModel>> GetAllByPatientIdAsync(SearchComment search);

    Task<BaseResult<List<CommentViewModel>>> GetAllFileInPaitent(int Id);

    Task<BaseResult> CreateAsync(CreateComment command);

    Task<BaseResult<ResultUploadFileChat>> CreateFileAsync(int patientId, int psychologistId, List<IFormFile> files);

    Task<BaseResult<ResultUploadFileChat>> CreatePatientFileAsync(int psychologistId, int patientId, List<IFormFile> files);

    Task<BaseResult<string>> CreateMessageAsync(int patientId, int psychologistId, string Message);

    Task<BaseResult<string>> CreatePatientMessageAsync(int psychologistId, int patientId, string Message);

    Task<BaseResult> IsVisitedAsync(string Id);
}