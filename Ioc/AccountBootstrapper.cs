using AutoMapper;
using Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ModelFactory;
using Repositories.Role;
using Repositories.User;
using Service.IRepository.Role;
using Service.IRepository.User;
using Service.IService.Account;
using Service.IService.User;
using Service.Service.Account;
using Service.Service.User;
using System.Text;

namespace Ioc;

public static class AccountBootstrapper
{
    public static IServiceCollection AccountConfig(this IServiceCollection services, string connection,
        string? JWTSecretKey)
    {
        services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connection));
        // Repository
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        // Service
        services.AddTransient(typeof(IUserService), typeof(UserService));
        services.AddTransient<IAuthService, AuthService>();
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