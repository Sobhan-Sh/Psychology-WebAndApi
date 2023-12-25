using AutoMapper;
using PC.Dto.Psychologist.PsychologistAboutUs;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.Psychologist;

namespace PC.Service.Service.Psychologist;

public class PsychologistAboutUsService : IPsychologistAboutUsService
{
    private readonly IPsychologistAboutUsRepository _aboutUsRepository;
    private IMapper _mapper;

    public PsychologistAboutUsService(IPsychologistAboutUsRepository aboutUsRepository, IMapper mapper)
    {
        _aboutUsRepository = aboutUsRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistAboutUsViewModel>>> GetAllAsync(SearchPsychologistAboutUs search)
    {
        try
        {
            List<PsychologistAboutUs> query = new List<PsychologistAboutUs>();
            if (search.PsychologistId < 1)
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
                IEnumerable<PsychologistAboutUs> PsychologistAboutUss = await _aboutUsRepository.GetAllAsync(include: "Psychologist");
                query.AddRange(PsychologistAboutUss.Where(x =>
                {
                    bool psId = search.PsychologistId < 0 || x.PsychologistId == search.PsychologistId;
                    return psId;
                }).Distinct().ToList());
            }

            if (!query.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success,
                    Data = new List<PsychologistAboutUsViewModel>()
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Count()),
                Data = _mapper.Map<List<PsychologistAboutUsViewModel>>(query),
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

    public async Task<BaseResult<List<PsychologistAboutUsViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<PsychologistAboutUs> query = await _aboutUsRepository.GetAllAsync(include: "Psychologist");
            if (!query.Any())
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistAboutUsViewModel>>(query),
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

    public async Task<BaseResult<EditPsychologistAboutUs>> GetAsync(int Id)
    {
        try
        {
            PsychologistAboutUs query = await _aboutUsRepository.GetAsync(x => x.Id == Id, include: "Psychologist");
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistAboutUs>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistAboutUs command)
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

            if (await _aboutUsRepository.IsExistAsync(x => x.Title == command.Title))
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            command.CreatedAt = DateTime.Now.ToString();
            command.IsActive = true;
            await _aboutUsRepository.CreateAsync(_mapper.Map<PsychologistAboutUs>(command));
            await _aboutUsRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreate,
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

    public async Task<BaseResult> UpdateAsync(EditPsychologistAboutUs command)
    {
        try
        {
            PsychologistAboutUs query = await _aboutUsRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };


            query.Edit(command.Title, command.TextAbout);
            await _aboutUsRepository.SaveAsync();
            return new()
            {
                Message = ValidationMessage.SuccessUpdate,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorUpdate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> DeleteAsync(int Id)
    {
        try
        {
            PsychologistAboutUs query = await _aboutUsRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _aboutUsRepository.DeleteAsync(query);
            await _aboutUsRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}