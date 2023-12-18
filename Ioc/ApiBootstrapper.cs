using Microsoft.Extensions.DependencyInjection;
using PC.Utility.Auth.IAuth;

namespace PC.Ioc;

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