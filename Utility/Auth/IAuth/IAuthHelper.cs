namespace Framework.Auth.IAuth;

public interface IAuthHelper
{
    bool IsAuthenticated();
    string CurrentAccountRole();
    long CurrentAccountId();
    string CurrentAccountMobile();
    string CurrentAccountFullName();
}