using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Psychologist;
using Service.IRepository.Psychologist;
using Service.IService.Psychologist;
using Service.Service.Psychologist;

namespace Ioc;

public static class PsychologistBootstrapper
{
    public static IServiceCollection PsychologistConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient<IPsychologistRepository, PsychologistRepository>();
        services.AddTransient<IPsychologistWorkingDateAndTimeRepository, PsychologistWorkingDateAndTimeRepository>();
        services.AddTransient<IPsychologistWorkingDaysRepository, PsychologistWorkingDaysRepository>();
        services.AddTransient<IPsychologistWorkingHoursRepository, PsychologistWorkingHoursRepository>();
        services.AddTransient<ITypeOfConsultationRepository, TypeOfConsultationRepository>();
        services.AddTransient<IPsychologistTypeOfConsultationRepository, PsychologistTypeOfConsultationRepository>();
        // Services
        services.AddTransient(typeof(IPsychologistService), typeof(PsychologistService));
        services.AddTransient(typeof(IPsychologistWorkingDateAndTimeService), typeof(PsychologistWorkingDateAndTimeService));
        services.AddTransient(typeof(IPsychologistWorkingDaysService), typeof(PsychologistWorkingDaysService));
        services.AddTransient(typeof(IPsychologistWorkingHoursService), typeof(PsychologistWorkingHoursService));
        services.AddTransient(typeof(ITypeOfConsultationService), typeof(TypeOfConsultationService));
        services.AddTransient(typeof(IPsychologistTypeOfConsultationService), typeof(PsychologistTypeOfConsultationService));

        return services;
    }
}