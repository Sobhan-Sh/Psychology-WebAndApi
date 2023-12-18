using AutoMapper;
using PC.Dto.Discount;
using PC.Service.IRepository.DiscountAndOrder;
using PC.Service.IService.DiscountAndOrder;
using PC.Utility.ReturnFuncResult;
using PC.Utility.Validation;
using PD.Entity.DiscountAndOrder;

namespace PC.Service.Service.DiscountAndOrder;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;
    private IMapper _mapper;

    public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<DiscountViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Discount> query = await _discountRepository.GetAllAsync(include: "Patient,Psychologist");
            if (!query.Any())
            {
                return new BaseResult<List<DiscountViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<DiscountViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<DiscountViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<DiscountViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<DiscountViewModel>>> GetAllAsync(SearchDiscount f)
    {
        try
        {
            List<Discount> query = new List<Discount>();
            if (f.DiscountWithMoney == 0 && f.DiscountWithPercentage == 0)
            {
                query.AddRange(await _discountRepository.GetAllAsync(include: "Patient,Psychologist"));
            }
            else
            {
                if (f.DiscountWithPercentage > 0)
                    query.AddRange(await _discountRepository.GetAllAsync(x => x.DiscountWithPercentage >= f.DiscountWithPercentage, include: "Patient,Psychologist"));

                if (f.DiscountWithMoney > 0)
                    query.AddRange(await _discountRepository.GetAllAsync(x => x.DiscountWithMoney >= f.DiscountWithMoney, include: "Patient,Psychologist"));
            }

            if (!query.Any())
                return new BaseResult<List<DiscountViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<DiscountViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<DiscountViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<DiscountViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditDiscount>> GetAsync(int Id)
    {
        try
        {
            Discount query = await _discountRepository.GetAsync(x => x.Id == Id, include: "Patient,Psychologist");
            if (query == null)
            {
                return new BaseResult<EditDiscount>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditDiscount>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditDiscount>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditDiscount>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<DiscountViewModel>> GetByPatientId(int Id)
    {
        try
        {
            Discount query = await _discountRepository.GetAsync(x => x.PatientId == Id);
            if (query == null)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<DiscountViewModel>(query),
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

    public async Task<BaseResult> CreateAsync(CreateDiscount command)
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

            if (await _discountRepository.IsExistAsync(x => x.PatientId == command.PatientId))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecordDiscountPatient,
                    StatusCode = ValidationCode.BadRequest
                };

            await _discountRepository.CreateAsync(_mapper.Map<Discount>(command));
            await _discountRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditDiscount command)
    {
        try
        {
            Discount query = await _discountRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.DiscountWithMoney, command.DiscountWithPercentage);
            await _discountRepository.SaveAsync();
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
            Discount query = await _discountRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _discountRepository.DeleteAsync(query);
            await _discountRepository.SaveAsync();
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
}