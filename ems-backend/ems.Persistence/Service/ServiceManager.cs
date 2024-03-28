using AutoMapper;
using ems.Common.model.Auth;
using ems.Common.model.Event;
using ems.Core.Contract.Common;
using ems.Core.Contract.Repository;
using ems.Core.Contract.Service;
using FluentValidation;

namespace ems.Persistence.Service;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthService> _lazyAuthService;
    private Lazy<IEventService> _lazyEventService;

    public ServiceManager(
        ITokenGenerator tokenGenerator,        
        IMapper mapper,
        IRepoManager repoManager,
        IValidator<Register> RegisterValidator,
        IValidator<RegisterDto> RegisterDtoValidator,
        IValidator<AddEventDto> AddEventDtoValidator
        )
    {
        _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(tokenGenerator, repoManager, RegisterValidator, mapper, RegisterDtoValidator));
        _lazyEventService = new Lazy<IEventService>(() => new EventService(repoManager, mapper, AddEventDtoValidator));
    }

    public IAuthService AuthService => _lazyAuthService.Value;
    public IEventService EventService => _lazyEventService.Value;
}
