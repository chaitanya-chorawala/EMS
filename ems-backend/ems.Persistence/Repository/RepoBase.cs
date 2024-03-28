using ems.Core.Contract.Repository;
using ems.Persistence.Configuration;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ems.Persistence.Repository;

public abstract class RepoBase<T> : IRepoBase<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public RepoBase(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
    public Task<T> FindByConditionFirstOrDefault(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
    public void Create(T entity) => _context.Set<T>().Add(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);

}
