using AutoMapper;
using Dto.Psychologist.PsychologistTypeOfConsultation;
using Entity.Psychologist;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Psychologist;

public class PsychologistTypeOfConsultationService : IPsychologistTypeOfConsultationService
{
    private readonly IPsychologistTypeOfConsultationRepository _psychologistTypeOfConsultationRepository;
    private readonly ITypeOfConsultationRepository _typeOfConsultationRepository;
    private readonly IPsychologistWorkingDateAndTimeRepository _workingDateAndTimeRepository;
    private IMapper _mapper;

    public PsychologistTypeOfConsultationService(IPsychologistTypeOfConsultationRepository psychologistTypeOfConsultationRepository, ITypeOfConsultationRepository typeOfConsultationRepository, IPsychologistWorkingDateAndTimeRepository workingDateAndTimeRepository, IMapper mapper)
    {
        _psychologistTypeOfConsultationRepository = psychologistTypeOfConsultationRepository;
        _typeOfConsultationRepository = typeOfConsultationRepository;
        _workingDateAndTimeRepository = workingDateAndTimeRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PsychologistTypeOfConsultationViewModel>>> GetAllAsync(SearchPsychologistTypeOfConsultation f)
    {
        try
        {
            List<PsychologistTypeOfConsultation> query = new List<PsychologistTypeOfConsultation>();
            if (f.PsychologistId < 1 && f.TypeOfConsultationId < 1)
            {
                query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(include: "Psychologist.User.Gender,TypeOfConsultation"));
            }
            else
            {
                if (f.PsychologistId > 0)
                    query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(x => x.PsychologistId == f.PsychologistId, include: "Psychologist.User.Gender,TypeOfConsultation"));

                if (f.TypeOfConsultationId > 0)
                    query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(x => x.TypeOfConsultationId == f.TypeOfConsultationId, include: "Psychologist.User.Gender,TypeOfConsultation"));

            }

            if (!query.Any())
                return new BaseResult<List<PsychologistTypeOfConsultationViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PsychologistTypeOfConsultationViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PsychologistTypeOfConsultationViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistTypeOfConsultationViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>>> ReturnNewModelInPageVisitGetAllAsync(SearchPsychologistTypeOfConsultation f)
    {
        try
        {
            List<PsychologistTypeOfConsultation> query = new List<PsychologistTypeOfConsultation>();
            if (f.PsychologistId < 1 && f.TypeOfConsultationId < 1)
            {
                query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(include: "Psychologist.User.Gender,TypeOfConsultation"));
            }
            else
            {
                if (f.PsychologistId > 0)
                    query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(x => x.PsychologistId == f.PsychologistId, include: "Psychologist.User.Gender,TypeOfConsultation"));

                if (f.TypeOfConsultationId > 0)
                    query.AddRange(await _psychologistTypeOfConsultationRepository.GetAllAsync(x => x.TypeOfConsultationId == f.TypeOfConsultationId, include: "Psychologist.User.Gender,TypeOfConsultation"));

            }

            if (!query.Any())
                return new BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            query = query.Where(x => !x.Psychologist.IsDeleted && x.Psychologist.IsActive).ToList();
            foreach (var ofConsultation in query)
            {
                if (await _workingDateAndTimeRepository.IsExistAsync(x => x.PsychologistId == ofConsultation.PsychologistId) == false)
                    query.RemoveAt(query.FindIndex(x => x.PsychologistId == ofConsultation.PsychologistId));
            }
            return new BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = Mapping.Mapping.ConvertPsychologistToNewModelPsychologistTypeOfConsultationInPageVisitViewModelMapping(query.Distinct().ToList()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<NewModelPsychologistTypeOfConsultationInPageVisitViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPsychologistTypeOfConsultation>> GetAsync(int Id)
    {
        try
        {
            PsychologistTypeOfConsultation query = await _psychologistTypeOfConsultationRepository.GetAsync(x => x.Id == Id, include: "Psychologist.User.Gender,TypeOfConsultation");
            if (query == null)
            {
                return new BaseResult<EditPsychologistTypeOfConsultation>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologistTypeOfConsultation>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologistTypeOfConsultation>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologistTypeOfConsultation>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePsychologistTypeOfConsultation command)
    {
        try
        {
            if (command == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            if (await _psychologistTypeOfConsultationRepository.IsExistAsync(x => x.PsychologistId == command.PsychologistId && x.TypeOfConsultationId == command.TypeOfConsultationId))
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            TypeOfConsultation typeOfConsultation = await _typeOfConsultationRepository.GetAsync(x => x.Id == command.TypeOfConsultationId);
            if (typeOfConsultation.IsDeleted)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordDelete,
                    StatusCode = ValidationCode.BadRequest
                };

            command.CreatedAt = DateTime.Now.ToString();
            command.IsActive = true;
            await _psychologistTypeOfConsultationRepository.CreateAsync(_mapper.Map<PsychologistTypeOfConsultation>(command));
            await _psychologistTypeOfConsultationRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreate,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> UpdateAsync(EditPsychologistTypeOfConsultation command)
    {
        try
        {
            if (!await _psychologistTypeOfConsultationRepository.IsExistAsync(x => x.Id == command.Id))
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (await _psychologistTypeOfConsultationRepository.IsExistAsync(x => x.TypeOfConsultationId == command.TypeOfConsultationId))
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            PsychologistTypeOfConsultation query =
                await _psychologistTypeOfConsultationRepository.GetAsync(x => x.Id == command.Id);
            query.Edit(command.PsychologistId, command.TypeOfConsultationId);
            await _psychologistTypeOfConsultationRepository.SaveAsync();
            return new BaseResult()
            {
                Message = ValidationMessage.SuccessUpdate,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
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
            PsychologistTypeOfConsultation query = await _psychologistTypeOfConsultationRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _psychologistTypeOfConsultationRepository.DeleteAsync(query);
            await _psychologistTypeOfConsultationRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<int>> ReturnDeleteAsync(int Id)
    {
        try
        {
            PsychologistTypeOfConsultation query = await _psychologistTypeOfConsultationRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult<int>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _psychologistTypeOfConsultationRepository.DeleteAsync(query);
            await _psychologistTypeOfConsultationRepository.SaveAsync();
            return new BaseResult<int>()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessDelete,
                StatusCode = ValidationCode.Success,
                Data = query.PsychologistId
            };
        }
        catch (Exception e)
        {
            return new BaseResult<int>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorDelete(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}