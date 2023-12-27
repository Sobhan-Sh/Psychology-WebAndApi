using AutoMapper;
using PC.Dto.Psychologist.Comment;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.Psychologist;

namespace PC.Service.Service.Psychologist;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
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
                IEnumerable<Comment> Comments = await _commentRepository.GetAllAsync(include: "Psychologist");
                query.AddRange(Comments.Where(x =>
                {
                    bool paId = search.PaitentId < 0 || x.PaitentId == search.PaitentId;
                    bool usId = search.UserId < 0 || x.UserId == search.UserId;
                    bool psyId = search.PsychologistId < 0 || x.PsychologistId == search.PsychologistId;
                    return psyId && usId && paId;
                }).Distinct().ToList());
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
                Message = ValidationMessage.SuccessGetAllSearch(query.Count()),
                Data = _mapper.Map<List<CommentViewModel>>(query),
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
}