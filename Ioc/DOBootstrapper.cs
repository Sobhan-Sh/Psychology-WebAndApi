using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC.Context;
using PC.Service.IRepository.DiscountAndOrder;
using PC.Service.IService.DiscountAndOrder;
using PC.Service.Service.DiscountAndOrder;
using PD.Repositories.DiscountAndOrder;

namespace PC.Ioc;

public static class DOBootstrapper
{
    public static IServiceCollection DOConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IDiscountRepository, DiscountRepository>();
        // Services
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IDiscountService, DiscountService>();

        return services;
    }
}