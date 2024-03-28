using System.Linq.Expressions;

namespace ems.Core.Contract.Repository;

public interface IRepoBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> FindByConditionFirstOrDefault(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
