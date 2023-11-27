using AutoMapper;
using Dto.account;
using Framework.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.IRepository.Role;
using Service.IRepository.User;
using Service.IService.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Utility.ReturnFuncResult;
using Utility.UploadFileTools;
using Utility.Validation;

namespace Service.Service.Account;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly AppSetting _appSetting;
    private IMapper _mapper;

    public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, IOptions<AppSetting> appSettings)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
        _appSetting = appSettings.Value;
    }

    public async Task<BaseResult<LoginResult>> LoginAsync(Login command)
    {
        try
        {
            Entity.User.User user = await _userRepository.GetAsync(x => x.Phone == command.CellPhone, "Role");
            if (user == null)
                return new BaseResult<LoginResult>()
                {
                    IsSuccess = false,
                    Message = ValidationMessage.RecordNotFound,
                    StatusCode = ValidationCode.NotFound
                };

            if (!user.IsActive)
                return new BaseResult<LoginResult>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.BadRequest,
                    Message = ValidationMessage.AccountIsBlock,
                };

            if (!user.MobailActiveStatus)
                return new BaseResult<LoginResult>()
                {
                    IsSuccess = false,
                    StatusCode = ValidationCode.BadRequest,
                    Message = ValidationMessage.ActivePhone,
                };

            PasswordHasher passwordHasher = new PasswordHasher();
            var verifyPass = passwordHasher.VerifyPassword(user.Password, command.Password);
            if (!verifyPass)
                return new BaseResult<LoginResult>
                {
                    IsSuccess = false,
                    Message = ValidationMessage.WrongPassword,
                    StatusCode = HttpStatusCode.BadRequest
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaims(new[]
            {
                new Claim(ClaimTypes.Name, $"{user.FName} {user.LName}"),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            await _userRepository.SaveAsync();
            return new BaseResult<LoginResult>()
            {
                IsSuccess = true,
                Data = new LoginResult
                {
                    Phone = user.Phone,
                    Role = user.Role.Name,
                    UserId = user.Id,
                    Token = tokenHandler.WriteToken(token),
                    Avatar = user.Avatar,
                },
                Message = ValidationMessage.SuccessLogin,
                StatusCode = ValidationCode.Success
            };
        }
        catch (Exception e)
        {
            return new BaseResult<LoginResult>()
            {
                StatusCode = ValidationCode.BadRequest,
                IsSuccess = false,
                Message = ValidationMessage.ErrorLogin(e.Message)
            };
        }
    }

    public async Task<BaseResult> RegisterAsync(Register command)
    {
        try
        {
            if (await _userRepository.IsExistAsync(x => x.Phone == command.Phone))
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.DuplicatedRecord,
                    StatusCode = HttpStatusCode.BadRequest
                };


            if (command.Password != command.ConfirmPassword)
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.PasswordsNotMatch,
                    StatusCode = HttpStatusCode.BadRequest
                };

            if (command.Password.Length < 5)

                return new BaseResult
                {
                    IsSuccess = false,
                    Message = ValidationMessage.PasswordLenght,
                    StatusCode = HttpStatusCode.BadRequest
                };

            if (command.ImageUser != null)
                if (command.ImageUser.IsCheckFile())
                {
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.ImageUser.FileName);
                    command.ImageUser.AddFileToServer(imageName, PathExtention.UserAvatarOriginServer, null, null);
                    command.Avatar = imageName;
                }
                else
                {
                    return new BaseResult()
                    {
                        IsSuccess = false,
                        Message = ValidationMessage.InvalidFileFormat,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

            var passwordHasher = new PasswordHasher();
            var randomCode = new Random().Next(1111, 9999);
            command.Password = passwordHasher.HashPassword(command.ConfirmPassword);
            command.RoleID = 2;
            command.MobailActiveStatus = true;

            command.ActivationCode = Guid.NewGuid().ToString("N");
            await _userRepository.CreateAsync(_mapper.Map<Entity.User.User>(command));
            await _userRepository.SaveAsync();

            //todo: Send randomCode to cellphone
            return new BaseResult
            {
                Message = ValidationMessage.SuccessRegister,
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
            };
        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                StatusCode = ValidationCode.BadRequest,
                IsSuccess = false,
                Message = ValidationMessage.ErrorLogin(e.Message)
            };
        }
    }
}