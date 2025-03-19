using FirstLibrary.Core.Northwind;
using System.Net.Http.Json;

namespace FirstDemo.Blazor.WebAssembly.Services;

public class ServizioWebCategorie : ICategorie
{
    private readonly HttpClient httpClient;
    private string baseAddress = "https://localhost:7199/";

    public ServizioWebCategorie(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        httpClient.BaseAddress = new Uri(baseAddress);
    }

    public async Task CreateCategoria(Categoria categoria)
    {
        var responseMessage = await httpClient.PostAsJsonAsync($"/categories/", categoria);
        if(responseMessage.IsSuccessStatusCode == true)
        {
            return;
        }
        else
        {
            throw new Exception("Errore nel recupero della categoria");
        }
    }

    public async Task DeleteCategoria(int id)
    {
        var responseMessage = await httpClient.DeleteAsync($"/categories/{id}");
        if (responseMessage.IsSuccessStatusCode == true)
        {
            return;
        }
        else
        {
            throw new Exception("Errore nel recupero della categoria");
        }

    }

    public async Task<Categoria?> GetCategoria(int id)
    {
        var responseMessage = await httpClient.GetAsync($"/categories/{id}");
        if (responseMessage.IsSuccessStatusCode == true)
        {
            return await responseMessage.Content
                     .ReadFromJsonAsync<Categoria>();
        }
        return null;
    }

    public async Task<IEnumerable<Categoria>?> GetCategorie()
    {
        var responseMessage = await httpClient.GetAsync("/categories");
        if (responseMessage.IsSuccessStatusCode == true)
        {
            return await responseMessage.Content
                     .ReadFromJsonAsync<IEnumerable<Categoria>>();
        }
        return null;
    }

    public async Task UpdateCategoria(Categoria categoria)
    {
        var responseMessage = await httpClient.PutAsJsonAsync($"/categories/{categoria.CategoryId}", categoria);
        if (responseMessage.IsSuccessStatusCode == true)
        {
            return;
        } else
        {
            throw new Exception("Errore nel recupero della categoria");
        }
    }

    IQueryable<Categoria>? ICategorie.GetCategorieQueryable()
    {
        throw new NotImplementedException();
    }
}
