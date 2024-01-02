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

            List<string> path = new();
            List<Comment> listComment = new();
            foreach (IFormFile file in files)
            {
                if (file.IsCheckFile())
                {
                    // create path
                    string pathFilePatient = PathExtention.PatientFile + "/" + patient.User.FullNameInCreateFolder() + "/";
                    // check && upload file
                    file.AddFileToServer(file.FileName, pathFilePatient, null, null);
                    path.Add(SD.BaseUrlProject + "PatientsFile/" + patient.User.FullNameInCreateFolder() + "/" + file.FileName);
                    listComment.Add(await _commentRepository.ReturnCreateAsync(new()
                    {
                        PaitentId = patientId,
                        PsychologistId = psychologistId,
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                        Sender = sender,
                        ObjPath = file.FileName,
                        IsVisit = false
                    }));
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
            string commmentId = "";
            for (int i = 0; i < listComment.Count; i++)
            {
                if (i == 0)
                    commmentId = listComment[i].Id.ToString();
                else
                    commmentId += "," + listComment[i].Id.ToString();
            }
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreateFileComment,
                StatusCode = ValidationCode.Success,
                Data = new()
                {
                    ListFilesPath = path,
                    ListFilesId = commmentId
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

    public async Task<BaseResult<string>> CreateMessageAsync(int patientId, int psychologistId, int sender, string Message)
    {
        try
        {
            PD.Entity.Patient.Patient patient = await _petientRepository.GetAsync(x => x.Id == patientId, include: "User");
            if (patient == null)
                return new()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.NotFound,
                    Message = ValidationMessage.RecordNotFound,
                };

            Comment query = await _commentRepository.ReturnCreateAsync(new()
            {
                PaitentId = patientId,
                CreatedAt = DateTime.Now,
                IsActive = true,
                Text = Message,
                PsychologistId = psychologistId,
                Sender = sender,
                IsDeleted = false,
                IsVisit = false
            });
            await _commentRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreateComment,
                StatusCode = ValidationCode.Success,
                Data = query.Id.ToString()
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

    public async Task<BaseResult> IsVisitedAsync(string Id)
    {
        try
        {
            if (Id.Length < 1)
                return new()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.BadRequest,
                    Message = ValidationMessage.Empty,
                };

            foreach (string num in Id.Split(','))
            {
                Comment query = await _commentRepository.GetAsync(x => x.Id == Convert.ToInt32(num));
                if (query == null)
                    return new()
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.RecordNotFound,
                        StatusCode = ValidationCode.NotFound,
                    };

                query.IsVisited();
            }

            await _commentRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessVisitedComment,
                StatusCode = ValidationCode.Success,
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