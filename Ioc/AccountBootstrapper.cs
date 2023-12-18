using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PC.Context;
using PC.Service.IRepository.Role;
using PC.Service.IRepository.User;
using PC.Service.IService.Account;
using PC.Service.IService.User;
using PC.Service.Service.Account;
using PC.Service.Service.User;
using PD.Repositories.Role;
using PD.Repositories.User;
using PF.ModelFactory;

namespace PC.Ioc;

public static class AccountBootstrapper
{
    public static IServiceCollection AccountConfig(this IServiceCollection services, string connection,
        string? JWTSecretKey)
    {
        services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connection));
        // Repository
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IGenderRepository, GenderRepository>();
        // Service
        services.AddTransient(typeof(IUserService), typeof(UserService));
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IGenderService, GenderService>();
        // Mapper
        IMapper mapper = MappProfile.RegisterMapp().CreateMapper();
        services.AddSingleton(mapper);
        services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());
        // Swagger
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Psychology Api With ASp Core 7", Version = "v1" });

            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
        // JWT
        var key = Encoding.ASCII.GetBytes(JWTSecretKey);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        return services;
    }
}