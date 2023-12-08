using AutoMapper;
using Dto.Patient.PatientTurn;
using Dto.Psychologist;
using Entity.DiscountAndOrder;
using Entity.Patient;
using Entity.Psychologist;
using Framework.Auth;
using Service.IRepository.DiscountAndOrder;
using Service.IRepository.Patient;
using Service.IRepository.Psychologist;
using Service.IRepository.User;
using Service.IService.Patient;
using Utility.ReturnFuncResult;
using Utility.Validation;

namespace Service.Service.Patient;

public class PatientTurnService : IPatientTurnService
{
    private readonly IUserRepository _userRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientTurnRepository _patientTurnRepository;
    private readonly ITypeOfConsultationRepository _typeOfConsultationRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IPsychologistWorkingDateAndTimeRepository _psychologistWorkingDate;
    private readonly IPsychologistTypeOfConsultationRepository _psychologistTypeOfConsultationRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IOrderRepository _orderRepository;
    private IMapper _mapper;

    public PatientTurnService(IUserRepository userRepository, IPatientRepository patientRepository, IPatientTurnRepository patientTurnRepository, ITypeOfConsultationRepository typeOfConsultationRepository, IPsychologistRepository psychologistRepository, IPsychologistWorkingDateAndTimeRepository psychologistWorkingDate, IPsychologistTypeOfConsultationRepository psychologistTypeOfConsultationRepository, IDiscountRepository discountRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _patientRepository = patientRepository;
        _patientTurnRepository = patientTurnRepository;
        _typeOfConsultationRepository = typeOfConsultationRepository;
        _psychologistRepository = psychologistRepository;
        _psychologistWorkingDate = psychologistWorkingDate;
        _psychologistTypeOfConsultationRepository = psychologistTypeOfConsultationRepository;
        _discountRepository = discountRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Entity.Patient.PatientTurn> query = await _patientTurnRepository.GetAllAsync(include: "Patient,Order,TypeOfConsultation,PsychologistWorkingDateAndTime");
            if (!query.Any())
            {
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<PatientTurnViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> GetAllAsync(SearchPatientTurn f)
    {
        try
        {
            List<Entity.Patient.PatientTurn> query = new List<Entity.Patient.PatientTurn>();
            if (f.ConsultationDay == null && f.Price < 1)
            {
                query.AddRange(await _patientTurnRepository.GetAllAsync(include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }
            else
            {
                if (f.Price > 0)
                    query.AddRange(await _patientTurnRepository.GetAllAsync(x => x.Price >= f.Price, include: "PsychologistWorkingDateAndTime,Discount,Order"));

                if (f.ConsultationDay != null)
                    query.AddRange(await _patientTurnRepository.GetAllAsync(x => x.ConsultationDay.Contains(f.ConsultationDay), include: "PsychologistWorkingDateAndTime,Discount,Order"));
            }

            if (!query.Any())
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<PatientTurnViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PsychologistViewModel>>> FindPsychologistByPatientIdAsync(int Id)
    {
        try
        {
            IEnumerable<Entity.Patient.PatientTurn> query = await _patientTurnRepository.GetAllAsync(x => x.PatientId == Id, include: "PsychologistWorkingDateAndTime.Psychologist");
            if (query == null)
            {
                return new BaseResult<List<PsychologistViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            List<PsychologistViewModel> listPsychologist = new List<PsychologistViewModel>();
            foreach (var item in query)
            {
                listPsychologist.Add(_mapper.Map<PsychologistViewModel>(item.PsychologistWorkingDateAndTime.Psychologist));
            }
            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = listPsychologist,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PsychologistViewModel>>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> FindPatientByPsychologistIdAsync(int Id)
    {
        try
        {
            IEnumerable<Entity.Patient.PatientTurn> query = await _patientTurnRepository.GetAllAsync(x => x.PsychologistWorkingDateAndTime.PsychologistId == Id, include: "Patient");
            if (!query.Any())
            {
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<List<PatientTurnViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<PatientTurnViewModel>>> UnvisitedPatients(int Id)
    {
        try
        {
            IEnumerable<Entity.Patient.PatientTurn> query = await _patientTurnRepository.GetAllAsync(x => x.PsychologistWorkingDateAndTime.PsychologistId == Id && x.IsVisited != true, include: "Patient");
            if (!query.Any())
            {
                return new BaseResult<List<PatientTurnViewModel>>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<List<PatientTurnViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<PatientTurnViewModel>>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditPatientTurn>> GetAsync(int Id)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id, include: "PsychologistWorkingDateAndTime,Discount,Order");
            if (query == null)
            {
                return new BaseResult<EditPatientTurn>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditPatientTurn>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditPatientTurn>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditPatientTurn>
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreatePatientTurn command)
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

            //TODO : ما اینجا باید محاسبه کنیم قیمت مشاوره رو بر اساس ساعت
            TypeOfConsultation typeOfConsultation = await _typeOfConsultationRepository.GetAsync(x => x.Id == command.TypeOfConsultationId);
            command.Price = 120000 + typeOfConsultation.Price;
            command.IsCanseled = false;
            command.IsVisited = false;
            await _patientTurnRepository.CreateAsync(_mapper.Map<Entity.Patient.PatientTurn>(command));
            await _patientTurnRepository.SaveAsync();
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

    public async Task<BaseResult> CreateAsync(SetVisitModel command)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(command.Name) || string.IsNullOrWhiteSpace(command.Phone) || command.TypeOfConsultationId < 1 || command.PsychologistId < 0 || command.TimeId < 0 || string.IsNullOrWhiteSpace(command.DateTimeVisit))
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.IsRequired,
                    StatusCode = ValidationCode.BadRequest
                };

            PsychologistTypeOfConsultation psychologistTypeOfConsultation =
                await _psychologistTypeOfConsultationRepository.GetAsync(
                    x => x.TypeOfConsultationId == command.TypeOfConsultationId &&
                         x.PsychologistId == command.PsychologistId, "TypeOfConsultation");
            if (psychologistTypeOfConsultation == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.BadRequest
                };

            PsychologistWorkingDateAndTime psychologistWorkingDateAndTime =
                await _psychologistWorkingDate.GetAsync(x =>
                    x.Id == command.TimeId && x.PsychologistId == command.PsychologistId, "PsychologistWorkingHours");
            if (psychologistWorkingDateAndTime == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.BadRequest
                };

            int patienId = 0, discountWithMoney = 0, discountWithPercentage = 0, price = 0, BasePrice = 120000 + psychologistTypeOfConsultation.TypeOfConsultation.Price;
            //TODO : ما اینجا باید محاسبه کنیم قیمت مشاوره رو بر اساس ساعت
            Entity.Patient.Patient user = await _patientRepository.GetAsync(x => x.User.Phone == command.Phone && x.User.RoleID == RoleHelper.Patient_Id);
            if (user != null)
            {
                patienId = user.Id;
                user.IsActive = true;
                Discount discountModel = await _discountRepository.GetAsync(x => x.PatientId == user.Id && x.PsychologistId == command.PsychologistId);
                if (discountModel != null)
                {
                    discountWithPercentage = (int)discountModel.DiscountWithPercentage;
                    discountWithMoney = (int)discountModel.DiscountWithMoney;
                }
            }
            else
            {
                // Create User
                Entity.User.User userModel = await _userRepository.ReturnCreateAsync(new()
                {
                    FName = command.Name,
                    LName = "پر نشده",
                    ActivationCode = "پر نشده",
                    CreatedAt = DateTime.Now,
                    GenderId = 3,
                    Password = "123456",
                    Phone = command.Phone,
                    IsDeleted = false,
                    IsActive = false,
                    RoleID = RoleHelper.Patient_Id,
                    MobailActiveStatus = false,
                });
                await _patientTurnRepository.SaveAsync();

                // Convert User To Patient
                Entity.Patient.Patient patientModel = await _patientRepository.ReturnCreateAsync(new()
                {
                    UserId = userModel.Id,
                    CreatedAt = DateTime.Now,
                    Age = 1,
                    IsActive = false,
                    IsDeleted = false,
                    NationalCode = "پر نشده",
                    TheReason = "پر نشده"
                });
                await _patientTurnRepository.SaveAsync();

                patienId = patientModel.Id;
            }

            price = BasePrice;
            if (discountWithPercentage > 0)
                price = (discountWithPercentage * price) / 100;

            if (discountWithMoney > 0)
                price = (price - discountWithMoney);

            // Appointment setting for the patient
            PatientTurn patientTurn = await _patientTurnRepository.ReturnCreateAsync(new()
            {
                Price = price,
                PatientId = patienId,
                IsActive = false,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                TypeOfConsultationId = command.TypeOfConsultationId,
                PsychologistWorkingDateAndTimeId = command.TimeId,
                IsVisited = false,
                IsCanseled = false,
                ConsultationDay = command.DateTimeVisit,
            });
            await _patientTurnRepository.SaveAsync();

            // set order
            Order order = await _orderRepository.ReturnCreateAsync(new()
            {
                IsPaid = false,
                IsActive = false,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                PatientTurnId = patientTurn.Id,
                Description = $"این فاکتور فقط ثبت شده و فاقد اعتبار است",
                PayAmount = price,
                TotalAmount = BasePrice,
                DiscountAmount = price - BasePrice,
                PatientId = patientTurn.PatientId,
                PsychologistId = command.PsychologistId,
                TestId = null,
                RefId = null
            });
            await _patientTurnRepository.SaveAsync();
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

    public async Task<BaseResult> UpdateAsync(EditPatientTurn command)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.Price, command.ConsultationDay, command.TypeOfConsultationId, command.PsychologistWorkingDateAndTimeId);
            await _patientTurnRepository.SaveAsync();
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
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            await _patientTurnRepository.DeleteAsync(query);
            await _patientTurnRepository.SaveAsync();
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

    public async Task<BaseResult> CanseledAsync(int Id)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Canseled();
            await _patientTurnRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCanseled,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCanseled(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> VisitedAsync(int Id)
    {
        try
        {
            Entity.Patient.PatientTurn query = await _patientTurnRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Visited();
            await _patientTurnRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessVisited,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorVisited(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}