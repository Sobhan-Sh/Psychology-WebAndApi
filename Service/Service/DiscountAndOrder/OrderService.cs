using AutoMapper;
using Dto.Order;
using Entity.DiscountAndOrder;
using Entity.Patient;
using Service.IRepository.DiscountAndOrder;
using Service.IRepository.Patient;
using Service.IRepository.Test;
using Service.IService.DiscountAndOrder;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.DiscountAndOrder;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly ITestRepository _testRepository;
    private readonly IPatientTurnRepository _patientTurnRepository;
    private IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IDiscountRepository discountRepository, ITestRepository testRepository, IPatientTurnRepository patientTurnRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _discountRepository = discountRepository;
        _testRepository = testRepository;
        _patientTurnRepository = patientTurnRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<OrderViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Order> query = await _orderRepository.GetAllAsync(include: "Patient,Psychologist,Test,PatientTurn");
            if (!query.Any())
            {
                return new BaseResult<List<OrderViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<OrderViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<OrderViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<OrderViewModel>>()
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
            List<Order> query = new List<Order>();
            if (f.IsPaid == null && f.DiscountAmount < 1 && f.PayAmount < 1 && f.TotalAmount < 1 && f.TestId < 1 && f.PatientTurnId < 1 && f.PsychologistId < 1)
            {
                if (!query.Any())
                    return new BaseResult<List<OrderViewModel>>
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.Vacant,
                        StatusCode = ValidationCode.BadRequest
                    };
            }
            else
            {
                if (f.TotalAmount > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.TotalAmount >= f.TotalAmount, include: "Patient,Psychologist,Test,PatientTurn"));
                
                if (f.IsPaid == null)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.IsPaid == f.IsPaid, include: "Patient,Psychologist,Test,PatientTurn"));
              
                if (f.PayAmount > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.PayAmount >= f.PayAmount, include: "Patient,Psychologist,Test,PatientTurn"));
               
                if (f.TotalAmount > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.TotalAmount >= f.TotalAmount, include: "Patient,Psychologist,Test,PatientTurn"));

                if (f.TestId > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.TestId == f.TestId, include: "Patient,Psychologist,Test,PatientTurn"));

                if (f.PatientTurnId > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.PatientTurnId == f.PatientTurnId, include: "Patient,Psychologist,Test,PatientTurn"));

                if (f.PsychologistId > 0)
                    query.AddRange(await _orderRepository.GetAllAsync(x => x.PsychologistId == f.PsychologistId, include: "Patient,Psychologist,Test,PatientTurn"));
            }

            if (!query.Any())
                return new BaseResult<List<OrderViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<OrderViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<OrderViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<OrderViewModel>>()
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
            Order query = await _orderRepository.GetAsync(x => x.Id == Id, include: "Patient,Psychologist,Test,PatientTurn");
            if (query == null)
            {
                return new BaseResult<EditOrder>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditOrder>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditOrder>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditOrder>
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

            int totalPrice = 0;
            command.TotalAmount = 0;
            command.DiscountAmount = 0;
            command.RefId = 0;
            if (command.TestId != null)
            {
                Entity.Test.Test test = await _testRepository.GetAsync(x => x.Id == command.TestId);
                totalPrice += test.Price;
            }

            if (command.PatientTurnId != null)
            {
                PatientTurn patientTurn = await _patientTurnRepository.GetAsync(x => x.Id == command.PatientTurnId);
                totalPrice += patientTurn.Price;
            }

            command.TotalAmount = totalPrice;
            if (await _discountRepository.IsExistAsync(x => x.PatientId == command.PatientId))
            {
                Discount discount = await _discountRepository.GetAsync(x => x.PatientId == command.PatientId);
                if (discount.DiscountWithMoney != null)
                {
                    command.DiscountAmount = discount.DiscountWithMoney;
                    totalPrice = (int)(totalPrice - command.DiscountAmount);
                }

                if (discount.DiscountWithPercentage != null)
                {
                    command.DiscountAmount = (100 / discount.DiscountWithPercentage) * totalPrice;
                    totalPrice = (int)(totalPrice - command.DiscountAmount);
                }
            }

            command.IsPaid = false;
            command.PayAmount = totalPrice;
            command.CreatedAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            await _orderRepository.CreateAsync(_mapper.Map<Order>(command));
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
            Order query = await _orderRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.PayAmount, command.DiscountAmount, command.TotalAmount, command.Description, command.IsPaid);
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
            Order query = await _orderRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

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

    public async Task<BaseResult> PaymentSuccessAsync(PaymentSuccess command)
    {
        Order order = await _orderRepository.GetAsync(x => x.Id == command.OrderId);
        if (order == null)
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };

        order.PaymentSuccess(command.RefId);
        order.Description = $"پرداخت شما در تاریخ {order.CreatedAt} با موفقیت انجام شد شماره فاکتور شما {order.Id}";
        await _orderRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActive,
            StatusCode = ValidationCode.Success
        };
    }
}