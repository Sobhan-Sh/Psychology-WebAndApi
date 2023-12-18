using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC.Context;
using PC.Service.IRepository.Test;
using PC.Service.IService.Test;
using PC.Service.Service.Test;
using PD.Repositories.Test;

namespace PC.Ioc;

public static class TestBootstrapper
{
    public static IServiceCollection TestConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient(typeof(ITestRepository), typeof(TestRepository));
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        services.AddTransient<IAnswerRepository, AnswerRepository>();
        // Services
        services.AddTransient(typeof(ITestService), typeof(TestService));
        services.AddTransient<IQuestionService, QuestionService>();
        services.AddTransient<IAnswerService, AnswerService>();

        return services;
    }
}