namespace FirstLibrary.Core.Northwind;

public interface ICategorie
{
    Task<IEnumerable<Categoria>> GetCategorie();
    Task<Categoria?> GetCategoria(int id);
    Task CreateCategoria(Categoria categoria);
    Task UpdateCategoria(Categoria categoria);
    Task DeleteCategoria(int id);
}

public interface IRepository<T,U>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(U id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(U id);
}
