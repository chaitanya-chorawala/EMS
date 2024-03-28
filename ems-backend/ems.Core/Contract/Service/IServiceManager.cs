namespace ems.Core.Contract.Service;

public interface IServiceManager
{
    IAuthService AuthService { get; }
    IEventService EventService { get; }
}
