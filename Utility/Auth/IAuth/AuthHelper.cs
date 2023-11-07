using Framework.Auth.IAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Framework.Auth;

public class AuthHelper : IAuthHelper
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthHelper(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public bool IsAuthenticated()
    {
        return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public string CurrentAccountRole()
    {
        if (IsAuthenticated())
            return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        return null;
    }

    public long CurrentAccountId()
    {
        var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        return IsAuthenticated() ? long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value)
            : 0;
    }

    public string CurrentAccountMobile()
    {
        return IsAuthenticated()
            ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.MobilePhone)?.Value
            : "";
    }

    public string CurrentAccountFullName()
    {
        return IsAuthenticated()
            ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name)?.Value
            : "";
    }
}