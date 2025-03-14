using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repositories.Implementation;

public class BaseRepository<T>(PostgresDbContext context) : IBaseRepository<T> where T : class
{
    public async Task<T?> CreateAsync(T entity)
    {
        EntityEntry<T> entry = context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        EntityEntry<T> entry = context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }
}