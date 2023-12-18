using Microsoft.AspNetCore.Mvc;
using PC.Dto.account;
using PC.Service.IService.Account;
using PC.Utility.ReturnFuncResult;

namespace Psychology.Controllers.Api.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResult<LoginResult>> Login([FromBody] Login p)
        {
            return await _authService.LoginAsync(p);
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<BaseResult> Register([FromForm] Register p)
        {
            return await _authService.RegisterAsync(p);
        }
    }
}
