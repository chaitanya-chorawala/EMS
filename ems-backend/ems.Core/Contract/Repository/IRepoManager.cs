namespace ems.Core.Contract.Repository;

public interface IRepoManager
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IEventRepo EventRepo { get; }
    IUserRepo UserRepo { get; }
}
