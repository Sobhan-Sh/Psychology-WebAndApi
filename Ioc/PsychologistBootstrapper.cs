using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC.Context;
using PC.Service.IRepository.Psychologist;
using PC.Service.IService.Psychologist;
using PC.Service.Service.Psychologist;
using PD.Repositories.Psychologist;

namespace PC.Ioc;

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
        services.AddTransient<IArticlesRepository, ArticlesRepository>();
        services.AddTransient<IPsychologistAboutUsRepository, PsychologistAboutUsRepository>();
        // Services
        services.AddTransient(typeof(IPsychologistService), typeof(PsychologistService));
        services.AddTransient(typeof(IPsychologistWorkingDateAndTimeService), typeof(PsychologistWorkingDateAndTimeService));
        services.AddTransient(typeof(IPsychologistWorkingDaysService), typeof(PsychologistWorkingDaysService));
        services.AddTransient(typeof(IPsychologistWorkingHoursService), typeof(PsychologistWorkingHoursService));
        services.AddTransient(typeof(ITypeOfConsultationService), typeof(TypeOfConsultationService));
        services.AddTransient(typeof(IPsychologistTypeOfConsultationService), typeof(PsychologistTypeOfConsultationService));
        services.AddTransient(typeof(IArticlesService), typeof(ArticlesService));
        services.AddTransient(typeof(IPsychologistAboutUsService), typeof(PsychologistAboutUsService));
        // Return Service IOC
        return services;
    }
}