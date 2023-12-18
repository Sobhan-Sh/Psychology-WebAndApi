namespace PC.Utility.Auth.IAuth;

public interface IAuthHelper
{
    bool IsAuthenticated();
    string CurrentAccountRole();
    int CurrentAccountId();
    string CurrentAccountMobile();
    string CurrentAccountFullName();
}