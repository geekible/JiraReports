using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ReportBuilder.Infrastructure.DataAccess.Repositories.Common;

public class CommonRepository<T>(ConfigApplicationDbContext dbContext) : ICommonRepository<T>
    where T : class
{
    public async Task<T> Get(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> Query(Expression<Func<T, bool>> predicate)
    {
        var query = dbContext.Set<T>().Where(predicate);
        var results = await query.ToListAsync();
        return results;
    }

    public async Task<T> Add(T entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int entityId)
    {
        var entity = await Get(entityId);
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}