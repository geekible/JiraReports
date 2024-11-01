using System.Linq.Expressions;

namespace ReportBuilder.Infrastructure.DataAccess.Repositories.Common;

public interface ICommonRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<IReadOnlyList<T>> Query(Expression<Func<T, bool>> predicate);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(int entityId);
}