using Microsoft.Extensions.DependencyInjection;
using PC.Utility.Auth.IAuth;

namespace PC.Utility.Bootstrapper;

public static class UtilityBootstrapper
{
    public static IServiceCollection UtitlityConfig(this IServiceCollection services)
    {
        services.AddTransient<IAuthHelper, AuthHelper>();
        return services;
    }
}