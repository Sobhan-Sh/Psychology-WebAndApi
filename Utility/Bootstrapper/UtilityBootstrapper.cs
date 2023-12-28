using Microsoft.Extensions.DependencyInjection;
using PC.Utility.Auth.IAuth;
using PC.Utility.ChatRoomService.IChatRoomSerive;

namespace PC.Utility.Bootstrapper;

public static class UtilityBootstrapper
{
    public static IServiceCollection UtitlityConfig(this IServiceCollection services)
    {
        services.AddTransient<IAuthHelper, AuthHelper>();
        services.AddTransient<IChatRoomService, ChatRoomService.ChatRoomService>();
        return services;
    }
}