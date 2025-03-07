using FirstLibrary.Core.Northwind;

namespace FirstDemo.Blazor.WebAssembly.Services;

public class ServizioWebCategorie : ICategorie
{
    public Task CreateCategoria(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoria(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Categoria?> GetCategoria(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Categoria>> GetCategorie()
    {
        await Task.Delay(1000);
        return new List<Categoria>
        {
            new Categoria {  CategoryId = 1, Nome = "Beverages", Descrizione = "Bla Bla", NumeroProdotti = 3 },
            new Categoria {  CategoryId = 2, Nome = "Condiments", Descrizione = "Bla Bla", NumeroProdotti = 3 },
            new Categoria {  CategoryId = 3, Nome = "Confections", Descrizione = "Bla Bla", NumeroProdotti = 3 },
            new Categoria {  CategoryId = 4, Nome = "Dairy Products", Descrizione = "Bla Bla", NumeroProdotti = 3 },
            new Categoria {  CategoryId = 5, Nome = "Grains/Cereals", Descrizione = "Bla Bla", NumeroProdotti = 3 },
            new Categoria {  CategoryId = 6, Nome = "Meat/Poultry", Descrizione = "Bla Bla", NumeroProdotti = 3 },
        };
    }

    public Task UpdateCategoria(Categoria categoria)
    {
        throw new NotImplementedException();
    }
}
