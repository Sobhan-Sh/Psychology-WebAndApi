﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC.Context;
using PC.Service.IRepository.Patient;
using PC.Service.IService.Patient;
using PC.Service.Service.Patient;
using PD.Repositories.Patient;

namespace PC.Ioc;

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
        // Services
        services.AddTransient(typeof(IPatientService), typeof(PatientService));
        services.AddTransient(typeof(IPatientFileService), typeof(PatientFileService));
        services.AddTransient(typeof(IPatientResponsesService), typeof(PatientResponsesService));
        services.AddTransient(typeof(IPatientTurnService), typeof(PatientTurnService));
        services.AddTransient(typeof(IPatientResponsesExamsService), typeof(PatientResponsesExamsService));
        // Return Service IOC
        return services;
    }
}