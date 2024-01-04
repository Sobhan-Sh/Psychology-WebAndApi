using AutoMapper;
using PC.Dto.Role;
using PC.Dto.User;
using PC.Service.IRepository.Patient;
using PC.Service.IRepository.Psychologist;
using PC.Service.IRepository.Role;
using PC.Service.IRepository.User;
using PC.Service.IService.User;
using PC.Utility.Auth;
using PC.Utility.ReturnFuncResult;
using PC.Utility.UploadFileTools;
using PC.Utility.Validation;

namespace PC.Service.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private IMapper _mapper;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IPatientRepository patientRepository, IPsychologistRepository psychologistRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _patientRepository = patientRepository;
        _psychologistRepository = psychologistRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<UserViewModel>>> GetAllAsync(SearchUserViewModel search)
    {
        try
        {
            List<PD.Entity.User.User> query = new List<PD.Entity.User.User>();
            if (string.IsNullOrWhiteSpace(search.FName) && string.IsNullOrWhiteSpace(search.LName) && string.IsNullOrWhiteSpace(search.Phone))
            {
                query.AddRange(await _userRepository.GetAllAsync(include: "Role,Gender"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search.LName))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.LName.Contains(search.LName), include: "Role,Gender"));

                if (!string.IsNullOrWhiteSpace(search.FName))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.FName.Contains(search.FName), include: "Role,Gender"));

                if (!string.IsNullOrWhiteSpace(search.Phone))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.Phone == search.Phone, include: "Role,Gender"));
            }


            if (!query.Any())
            {
                return new BaseResult<List<UserViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<UserViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAllSearch(query.Distinct().Count()),
                Data = _mapper.Map<List<UserViewModel>>(query.Distinct()),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<UserViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<List<UserViewModel>>> GetAllAsync()
    {
        try
        {
            IEnumerable<PD.Entity.User.User> query = await _userRepository.GetAllAsync(include: "Role,Gender");
            if (!query.Any())
            {
                return new BaseResult<List<UserViewModel>>
                {
                    IsSuccess = true,
                    Message = ValidationMessage.Vacant,
                    Data = new List<UserViewModel>(),
                    StatusCode = ValidationCode.Success
                };
            }

            return new BaseResult<List<UserViewModel>>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGetAll,
                Data = _mapper.Map<List<UserViewModel>>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<List<UserViewModel>>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGetAll(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<EditUser>> GetAsync(int Id)
    {
        try
        {
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id, "Role,Gender");
            if (query == null)
            {
                return new BaseResult<EditUser>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<EditUser>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<EditUser>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<EditUser>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult<UserViewModel>> ReturnViewGetAsync(int Id)
    {
        try
        {
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id, "Role,Gender");
            if (query == null)
            {
                return new BaseResult<UserViewModel>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.NoFoundGet,
                    StatusCode = ValidationCode.NotFound
                };
            }

            return new BaseResult<UserViewModel>
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessGet,
                Data = _mapper.Map<UserViewModel>(query),
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<UserViewModel>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorGet(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> CreateAsync(CreateUser command)
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

            if (await _userRepository.IsExistAsync(x => x.Phone == command.Phone))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            if (command.ImageUser != null)
            {
                if (command.ImageUser.IsCheckFile())
                {
                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageUser.FileName);
                    command.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, 100, 100, true, null);
                    command.Avatar = imageName;
                }
                else
                {
                    return new BaseResult() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };
                }
            }

            var passwordHasher = new PasswordHasher();
            command.Password = passwordHasher.HashPassword(command.Password);
            command.RoleID = 2;
            command.IsActive = false;
            command.MobailActiveStatus = false;
            command.ActivationCode = Guid.NewGuid().ToString();
            await _userRepository.CreateAsync(_mapper.Map<PD.Entity.User.User>(command));
            await _userRepository.SaveAsync();
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

    public async Task<BaseResult<int>> ReturnCreateAsync(CreateUser command)
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

            if (await _userRepository.IsExistAsync(x => x.Phone == command.Phone))
                return new()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = ValidationCode.BadRequest
                };

            if (command.ImageUser != null)
            {
                if (command.ImageUser.IsCheckFile())
                {
                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageUser.FileName);
                    command.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, 100, 100, true, null);
                    command.Avatar = imageName;
                }
                else
                {
                    return new() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };
                }
            }

            var passwordHasher = new PasswordHasher();
            command.Password = passwordHasher.HashPassword(command.Password);
            command.RoleID = 2;
            command.IsActive = false;
            command.MobailActiveStatus = false;
            command.ActivationCode = Guid.NewGuid().ToString();
            PD.Entity.User.User user = await _userRepository.ReturnCreateAsync(_mapper.Map<PD.Entity.User.User>(command));
            await _userRepository.SaveAsync();
            return new()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCreate,
                StatusCode = ValidationCode.Success,
                Data = user.Id
            };
        }
        catch (Exception e)
        {
            UploadImageExtension.DeleteImage(command.Avatar, PathExtention.UserAvatarOriginServer, null);
            return new()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorCreate(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> UpdateAsync(EditUser command)
    {
        try
        {
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (command.ImageUser != null)
            {
                if (command.ImageUser.IsCheckFile())
                {
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageUser.FileName);
                    command.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, 100, 100, false, command.Avatar);
                    command.Avatar = imageName;
                }
                else
                {
                    return new BaseResult() { IsSuccess = false, Message = ValidationMessage.InvalidFileFormat, StatusCode = ValidationCode.BadRequest };
                }
            }

            query.Edit(command.FName, command.LName, command.Address, command.Avatar, command.RoleID, command.GenderId);
            await _userRepository.SaveAsync();
            return new BaseResult()
            {
                Message = ValidationMessage.SuccessUpdate,
                StatusCode = ValidationCode.Success,
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            if (File.Exists(PathExtention.UserAvatarOriginServer + command.Avatar))
                File.Delete(PathExtention.UserAvatarOriginServer + command.Avatar);
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
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            PD.Entity.Patient.Patient patient = await _patientRepository.GetAsync(x => x.UserId == Id);
            PD.Entity.Psychologist.Psychologist psychologist = await _psychologistRepository.GetAsync(x => x.UserId == Id);
            if (patient != null)
                _patientRepository.DeleteAsync(patient);

            if (psychologist != null)
                _psychologistRepository.DeleteAsync(psychologist);

            if (!string.IsNullOrWhiteSpace(query.Avatar))
            {
                if (File.Exists(PathExtention.UserAvatarOriginServer + query.Avatar))
                    File.Delete(PathExtention.UserAvatarOriginServer + query.Avatar);
            }

            await _userRepository.DeleteAsync(query);
            await _userRepository.SaveAsync();
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

    public async Task<BaseResult> ActivePhone(int Id)
    {
        var appUser = await _userRepository.GetAsync(x => x.Id == Id);
        if (appUser == null)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };
        }
        appUser.ActiveMobail();
        await _userRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessActivePhone,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> BlockAsync(int Id)
    {
        var appUser = await _userRepository.GetAsync(x => x.Id == Id);
        if (appUser == null)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };
        }

        appUser.DeActive();
        await _userRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.Blocked,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> OnBlockAsync(int Id)
    {
        var appUser = await _userRepository.GetAsync(x => x.Id == Id);
        if (appUser == null)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound
            };
        }

        appUser.Active();
        await _userRepository.SaveAsync();
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.OnBlocked,
            StatusCode = ValidationCode.Success
        };
    }

    public async Task<BaseResult> ChangePasswordAsync(ChangePassword command)
    {
        PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id);
        if (query == null)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound,
            };
        }

        if (command.NewPassword.Length < 5)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.PasswordLenght,
                StatusCode = ValidationCode.BadRequest,
            };
        }

        if (command.NewPassword != command.ConfirmNewPassword)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.NoConfirmPassword,
                StatusCode = ValidationCode.BadRequest,
            };
        }

        var passwordHasher = new PasswordHasher();
        if (passwordHasher.VerifyPassword(query.Password, command.Password))
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.WrongPassword,
                StatusCode = ValidationCode.BadRequest,
            };

        query.Password = passwordHasher.HashPassword(command.NewPassword);
        await _userRepository.SaveAsync();
        //todo: Send onHashPass To User phone By SMS
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.SuccessUpdatePassword,
            StatusCode = ValidationCode.Success,
        };
    }

    public async Task<BaseResult> ChangePasswordAsync(AdminChangePasswored command)
    {
        PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id, include: "Gender");
        if (query == null)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.RecordNotFound,
                StatusCode = ValidationCode.NotFound,
            };
        }

        if (command.NewPassword.Length < 5)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.PasswordLenght,
                StatusCode = ValidationCode.BadRequest,
            };
        }

        if (command.NewPassword != command.ConfirmNewPassword)
        {
            return new BaseResult
            {
                IsSuccess = false,
                Message = ValidationMessage.NoConfirmPassword,
                StatusCode = ValidationCode.BadRequest,
            };
        }

        var passwordHasher = new PasswordHasher();
        query.Password = passwordHasher.HashPassword(command.NewPassword);
        await _userRepository.SaveAsync();
        //todo: Send onHashPass To User phone By SMS
        return new BaseResult
        {
            IsSuccess = true,
            Message = ValidationMessage.AdminSuccessUpdatePassword(query.FullName(), query.Gender.Name),
            StatusCode = ValidationCode.Success,
        };
    }

    public async Task<BaseResult<ResultFindUserAuth>> ChangeAuth(int Id)
    {
        try
        {
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult<ResultFindUserAuth>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            return new BaseResult<ResultFindUserAuth>()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessCheckUserBeforeChangeAuth,
                StatusCode = ValidationCode.Success,
                Data = new ResultFindUserAuth()
                {
                    Id = query.Id,
                    RoleViewModels = _mapper.Map<List<RoleViewModel>>(await _roleRepository.GetAllAsync(x => x.Id > 1)),
                    RoleId = query.RoleID
                }
            };
        }
        catch (Exception e)
        {
            return new BaseResult<ResultFindUserAuth>()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorChackUserInChangeAuth(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }

    public async Task<BaseResult> ChangeAuth(ChangeAuth command)
    {
        try
        {
            PD.Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.ChangeAuth(command.RoleId);
            await _userRepository.SaveAsync();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = ValidationMessage.SuccessChangeAuth,
                StatusCode = ValidationCode.Success,
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                IsSuccess = false,
                Message = ValidationMessage.ErrorChangeAuth(e.Message),
                StatusCode = ValidationCode.BadRequest
            };
        }
    }
}