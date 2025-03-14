using FirstLibrary.Core.Northwind;
using System.Net.Http.Json;

namespace FirstDemo.Blazor.WebAssembly.Services;

public class ServizioWebCategorie : ICategorie
{
    private readonly HttpClient httpClient;

    public ServizioWebCategorie(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

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

    public async Task<IEnumerable<Categoria>?> GetCategorie()
    {
        httpClient.BaseAddress = new Uri("https://localhost:7199/");
        var responseMessage = await httpClient.GetAsync("/categories");
        if (responseMessage.IsSuccessStatusCode == true)
        {
            return await responseMessage.Content
                     .ReadFromJsonAsync<IEnumerable<Categoria>>();
        }
        return null;
    }

    public Task<IQueryable<Categoria>> GetCategorieQueryable()
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoria(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    IQueryable<Categoria>? ICategorie.GetCategorieQueryable()
    {
        throw new NotImplementedException();
    }
}
