using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Patient;
using Service.IRepository.Patient;
using Service.IService.Patient;
using Service.Service.Patient;

namespace Ioc;

public static class PatientBootstrapper
{
    public static IServiceCollection PatientConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient(typeof(IPatientRepository), typeof(PatientRepository));
        services.AddTransient(typeof(IPatientExamRepository), typeof(PatientExamRepository));
        services.AddTransient(typeof(IPatientFileRepository), typeof(PatientFileRepository));
        services.AddTransient(typeof(IPatientResponsRepository), typeof(PatientResponsesRepository));
        services.AddTransient(typeof(IPatientTurnRepository), typeof(PatientTurnRepository));
        services.AddTransient(typeof(ICommentRepository), typeof(CommentRepository));
        // Services
        services.AddTransient(typeof(IPatientService), typeof(PatientService));
        services.AddTransient(typeof(IPatientFileService), typeof(PatientFileService));
        services.AddTransient(typeof(IPatientResponsesService), typeof(PatientResponsesService));
        services.AddTransient(typeof(IPatientTurnService), typeof(PatientTurnService));

        return services;
    }
}