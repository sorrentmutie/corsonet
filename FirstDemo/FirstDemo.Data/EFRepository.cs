using FirstLibrary.Core.Common;
using Microsoft.EntityFrameworkCore;
namespace FirstDemo.Data;

public class EFRepository<TEntity, TKey>
    : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public EFRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        dbSet.Add(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = new TEntity { Id = id };
        dbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }

    public IQueryable<TEntity> GetAll()
    {
        return dbSet.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await dbSet.FindAsync(id);
        if(entity == null)
        {
            return null;
        }
        dbContext.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        dbSet.Update(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }
}
