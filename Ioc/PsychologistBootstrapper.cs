using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Psychologist;
using Service.IRepository.Psychologist;

namespace Ioc;

public static class PsychologistBootstrapper
{
    public static IServiceCollection PsychologistConfig(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        // Repositories
        services.AddTransient(typeof(IPsychologistRepository), typeof(PsychologistRepository));
        services.AddTransient<IPsychologistWorkingDateAndTimeRepository, PsychologistWorkingDateAndTimeRepository>();
        services.AddTransient<IPsychologistWorkingDaysRepository, PsychologistWorkingDaysRepository>();
        services.AddTransient(typeof(IPsychologistWorkingHoursRepository), typeof(IPsychologistWorkingHoursRepository));
        services.AddTransient<ITypeOfConsultationRepository, TypeOfConsultationRepository>();
        // Services

        return services;
    }
}