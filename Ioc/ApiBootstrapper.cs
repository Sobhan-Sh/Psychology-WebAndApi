using Framework.Auth;
using Framework.Auth.IAuth;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc;

public class ApiBootstrapper
{
    public static void ApiConfig(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();

        //services.AddCors(options => {
        //    options.AddPolicy("Psychology", builder => {
        //        builder.AllowAnyOrigin()
        //            .AllowAnyMethod()
        //            .AllowAnyHeader();
        //    });
        //});

        services.AddTransient<IAuthHelper, AuthHelper>();
    }
}