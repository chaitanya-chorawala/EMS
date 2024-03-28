using ems.Common.model.Auth;
using ems.Common.model.Event;
using ems.Core.Contract.Common;
using ems.Core.Contract.Repository;
using ems.Core.Contract.Service;
using ems.Persistence.Common;
using ems.Persistence.Repository;
using ems.Persistence.Service;
using ems.Persistence.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ems.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.TryAddScoped<IRepoManager, RepoManager>();
        services.TryAddScoped<IServiceManager, ServiceManager>();

        services.TryAddScoped<IClaimPrincipalAccessor, ClaimPrincipalAccessor>();
        services.TryAddScoped<ITokenGenerator, TokenGenerator>();        

        services.AddScoped<IValidator<AddEventDto>, EventValidator>();
        services.AddScoped<IValidator<Register>, RegistrationValidator>();
        services.AddScoped<IValidator<RegisterDto>, UpdateRegistrationValidation>();

        return services;
    }
}