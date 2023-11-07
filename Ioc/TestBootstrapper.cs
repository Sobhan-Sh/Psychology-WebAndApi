using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Test;
using Service.IRepository.Test;
using Service.IService.Test;
using Service.Service.Test;

namespace Ioc;

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