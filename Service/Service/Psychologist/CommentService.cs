using AutoMapper;
using Microsoft.AspNetCore.Http;
using PC.Dto.Psychologist.Comment;
using PC.Service.IRepository.Patient;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Utility;
using PC.Utility.ReturnFuncResult;
using PC.Utility.UploadFileTools;
using PC.Utility.Validation;
using PD.Entity.Psychologist;

namespace PC.Service.Service.Psychologist;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IPatientRepository _petientRepository;
    private IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IPsychologistRepository psychologistRepository, IPatientRepository petientRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _psychologistRepository = psychologistRepository;
        _petientRepository = petientRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<CommentViewModel>>> GetAllAsync(SearchComment search)
    {
        try
        {
            List<Comment> query = new List<Comment>();
            if (search.PsychologistId < 1 && search.UserId < 1 && search.PaitentId < 1)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }
            else
            {
                if (search.PsychologistId > 0 && search.PaitentId > 0)
                {
                    query.AddRange(await _commentRepository.GetAllAsync(x => x.PaitentId == search.PaitentId && x.PsychologistId == search.PsychologistId, include: "Psychologist,Patient.User"));
                }
                else
                {
                    if (search.PaitentId > 0)
                        query.AddRange(await _commentRepository.GetAllAsync(x => x.PaitentId == search.PaitentId, include: "Psychologist,Patient.User"));
                    if (search.PsychologistId > 0)
                        query.AddRange(await _commentRepository.GetAllAsync(x => x.PsychologistId == search.PsychologistId, include: "Psychologist,Patient.User"));
                }

                if (search.PsychologistId > 0 && search.UserId > 0)
                    query.AddRange(await _commentRepository.GetAllAsync(x => x.PsychologistId == search.PsychologistId && x.UserId == search.UserId, include: "Psychologist,User"));
                else if (search.UserId > 0)
                    query.AddRange(await _commentRepository.GetAllAsync(x => x.UserId == search.UserId, include: "Psychologist,User"));

            }

            if (!query.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success,
                    Data = new List<CommentViewModel>()
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<CommentViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateComment command)
    {
        try
        {
            if (command == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            command.CreatedAt = DateTime.Now.ToString();
            command.IsActive = false;
            await _commentRepository.CreateAsync(_mapper.Map<Comment>(command));
            await _commentRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                //  Message = ValidationMessage.SuccessCreateComment,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<ResultUploadFileChat>> CreateFileAsync(int patientId, int psychologistId, int sender, List<IFormFile> files)
    {
        try
        {
            PD.Entity.Patient.Patient patient = await _petientRepository.GetAsync(x => x.Id == patientId, include: "User");
            if (!files.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            if (patient == null)
                return new()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.RecordNotFound,
                    Data = new()
                };

            List<string> path = new List<string>();
            foreach (IFormFile file in files)
            {
                if (file.IsCheckFile())
                {
                    // create path
                    string pathFilePatient = PathExtention.PatientFile + "/" + patient.User.FullNameInCreateFolder() + "/";
                    // check && upload file
                    file.AddFileToServer(file.FileName, pathFilePatient, null, null);
                    path.Add(SD.BaseUrlProject + "PatientsFile/" + patient.User.FullNameInCreateFolder() + "/" + file.FileName);
                    await _commentRepository.CreateAsync(new()
                    {
                        PaitentId = patientId,
                        PsychologistId = psychologistId,
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                        Sender = sender,
                        ObjPath = file.FileName,
                    });
                }
                else
                    return new()
                    {
                        Data = new(),
                        IsSuccess = false,
                        Message = ValidationMessage.InvalidFileFormat,
                        StatusCode = ValidationCode.BadRequest
                    };
            }

            await _commentRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreateFileComment,
                StatusCode = ValidationCode.Success,
                Data = new()
                {
                    ListFilesPath = path
                }
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}