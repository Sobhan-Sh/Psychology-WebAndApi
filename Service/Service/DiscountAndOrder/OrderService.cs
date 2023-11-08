using AutoMapper;
using Dto.Order;
using Dto.Psychologist;
using Service.IRepository.DiscountAndOrder;
using Service.IService.DiscountAndOrder;
using Utility.ReturnFuncResult;
using Utility.UploadFileTools;
using Utility.Validation;

namespace Service.Service.DiscountAndOrder;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDiscountRepository _discountRepository;
    private IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IDiscountRepository discountRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<OrderViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.DiscountAndOrder.Order> query = await _orderRepository.GetAllAsync(include: "Patient,Psychologist,Test,PatientTurn");
            if (!query.Any())
            {
                return new BaseResult<List<PsychologistViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PsychologistViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<OrderViewModel>>> GetAllAsync(SearchOrder f)
    {
        try
        {
            List<Entity.DiscountAndOrder.Order> query = new List<Entity.DiscountAndOrder.Order>();
            if (string.IsNullOrWhiteSpace(f.MedicalLicennseCode) && string.IsNullOrWhiteSpace(f.NationalCode) && f.DateOfBirth == null && f.Age! > 0 && f.Commission! > 0)
            {
                query.AddRange(await _orderRepository.GetAllAsync(include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(f.MedicalLicennseCode))
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.MedicalLicennseCode.Contains(f.MedicalLicennseCode), include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (!string.IsNullOrWhiteSpace(f.NationalCode))
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.NationalCode.Contains(f.NationalCode), include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.DateOfBirth != null)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.DateOfBirth <= f.DateOfBirth, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.Age > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.Age <= f.Age, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.Commission > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.Commission <= f.Commission, include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }

            if (!query.Any())
                return new BaseResult<List<PsychologistViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PsychologistViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditOrder>> GetAsync(int Id)
    {
        try
        {
            Entity.DiscountAndOrder.Order query = await _orderRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingDateAndTime,Discount,Order");
            if (query == null)
            {
                return new BaseResult<EditPsychologist>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPsychologist>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPsychologist>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPsychologist>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateOrder command)
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

            if (await _orderRepository.IsExistAsync(x => x.NationalCode == command.NationalCode))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            if (await _orderRepository.IsExistAsync(x => x.MedicalLicennseCode == command.MedicalLicennseCode))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecordLicennseCode,
                    StatusCode = ValidationCode.BadRequest
                };

            if (command.ImageLicennse != null)
                if (command.ImageLicennse.IsCheckFile())
                {
                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageLicennse.FileName);
                    command.ImageLicennse.AddFileToServer(imageName, PathExtention.PathImageLicennsePsychologist, null, null, null, null);
                    command.EvidencePath = imageName;
                }

            await _orderRepository.CreateAsync(_mapper.Map<Entity.DiscountAndOrder.Order>(command));
            await _orderRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditOrder command)
    {
        try
        {
            Entity.DiscountAndOrder.Order query = await _orderRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (command.ImageLicennse != null)
                if (command.ImageLicennse.IsCheckFile())
                {
                    var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageLicennse.FileName);
                    command.ImageLicennse.AddFileToServer(fileName, /* Create Path */PathExtention.PathImageLicennsePsychologist, null, null, null, null);
                    command.EvidencePath = fileName;
                }

            query.Edit(command.Age, command.NationalCode, command.EvidencePath, command.DateOfBirth, command.MedicalLicennseCode);
            await _orderRepository.SaveAsync();
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
            Entity.DiscountAndOrder.Order query = await _orderRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (!string.IsNullOrWhiteSpace(query.EvidencePath))
            {
                if (File.Exists(PathExtention.PathImageLicennsePsychologist + query.EvidencePath))
                    File.Delete(PathExtention.PathImageLicennsePsychologist + query.EvidencePath);
            }

            await _orderRepository.DeleteAsync(query);
            await _orderRepository.SaveAsync();
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