using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using rayna.Common.model.Auth;
using rayna.Common.model.Rayna;
using rayna.Core.Contract.Common;
using rayna.Core.Contract.Repository;
using rayna.Core.Contract.Service;
using rayna.Persistence.Common;
using rayna.Persistence.Configuration;
using rayna.Persistence.Repository;
using rayna.Persistence.Service;
using rayna.Persistence.Validation;

namespace rayna.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("connStr"), sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.CommandTimeout(180);
                sqlServerOptionsAction.EnableRetryOnFailure(2);
            });
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
            options.LogTo(Console.WriteLine);
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.TryAddScoped<IUserRepo, UserRepo>();
        services.TryAddScoped<IClaimPrincipalAccessor, ClaimPrincipalAccessor>();
        services.TryAddScoped<ITokenGenerator, TokenGenerator>();
        services.TryAddScoped<IAuthService, AuthService>();

        services.AddTransient<IEventRepo, EventRepo>();
        services.AddTransient<IEventService, EventService>();

        services.AddScoped<IValidator<AddEventDto>, EventValidator>();
        services.AddScoped<IValidator<Register>, RegistrationValidator>();
        services.AddScoped<IValidator<RegisterDto>, UpdateRegistrationValidation>();

        return services;
    }
}