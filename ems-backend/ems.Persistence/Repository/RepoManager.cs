using AutoMapper;
using ems.Core.Contract.Repository;
using ems.Persistence.Configuration;

namespace ems.Persistence.Repository;

public class RepoManager : IRepoManager
{
    private readonly Lazy<IEventRepo> _lazyEventRepo;
    private readonly Lazy<IUserRepo> _lazyUserRepo;
    private readonly ApplicationDbContext _context;

    public RepoManager(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _lazyEventRepo = new Lazy<IEventRepo>(() => new EventRepo(context, mapper));
        _lazyUserRepo = new Lazy<IUserRepo>(() => new UserRepo(context));
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

    public IEventRepo EventRepo => _lazyEventRepo.Value;

    public IUserRepo UserRepo => _lazyUserRepo.Value;

}
