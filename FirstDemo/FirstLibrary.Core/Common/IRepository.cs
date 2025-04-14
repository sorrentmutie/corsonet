namespace FirstLibrary.Core.Common;

public interface IRepository<TEntity, TKey>
    where TEntity: class, IEntity<TKey>, new()
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);

    Task SaveChangesAsync();
}
