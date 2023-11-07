using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.DiscountAndOrder;
using Service.IRepository.DiscountAndOrder;

namespace Ioc;

public static class DOBootstrapper
{
    public static IServiceCollection DOConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IDiscountRepository, DiscountRepository>();
        // Services

        return services;
    }
}