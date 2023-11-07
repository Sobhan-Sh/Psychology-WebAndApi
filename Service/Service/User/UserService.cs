using AutoMapper;
using Dto.User;
using Framework.Auth;
using Service.IRepository.User;
using Service.IService.User;
using Utility.ReturnFuncResult;
using Utility.UploadFileTools;
using Utility.Validation;

namespace Service.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<List<UserViewModel>>> GetAllAsync(SearchUserViewModel search)
    {
        try
        {
            List<Entity.User.User> query = new List<Entity.User.User>();
            if (string.IsNullOrWhiteSpace(search.FName) && string.IsNullOrWhiteSpace(search.LName) && string.IsNullOrWhiteSpace(search.Phone))
            {
                query.AddRange(await _userRepository.GetAllAsync(include: "Role"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search.LName))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.LName.Contains(search.LName), include: "Role"));

                if (!string.IsNullOrWhiteSpace(search.FName))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.FName.Contains(search.FName), include: "Role"));

                if (!string.IsNullOrWhiteSpace(search.Phone))
                    query.AddRange(await _userRepository.GetAllAsync(x => x.Phone == search.Phone, include: "Role"));
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
            IEnumerable<Entity.User.User> query = await _userRepository.GetAllAsync(include: "Role");
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
            Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id, "Role");
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
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageUser.FileName);
                    command.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, null, null, null, null);
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
            await _userRepository.CreateAsync(_mapper.Map<Entity.User.User>(command));
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

    public async Task<BaseResult> UpdateAsync(EditUser command)
    {
        try
        {
            Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            query.Edit(command.FName, command.LName, command.Address, command.Avatar, command.RoleID,command.Gender);
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
            Entity.User.User query = await _userRepository.GetAsync(x => x.Id == Id);
            if (query == null)
                return new BaseResult()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

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
        Entity.User.User query = await _userRepository.GetAsync(x => x.Id == command.Id);
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
        if (query.Password != passwordHasher.HashPassword(command.Password))
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
}