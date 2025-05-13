using FirstLibrary.Core.Configurations;
using FirstDemo.UI.Kit.DataTypes;
using Microsoft.Extensions.Options;
using FirstDemo.UI.Kit.Interfaces;

namespace FirstDemo.BLazor.Server.Services;

public class ServizioAPIGenerico<T> : IServizioAPIGenerico<T> where T : class
{
    private readonly IHttpClientFactory httpClientFactory;
    private CancellationTokenSource? cancellationTokenSource;
    private readonly IOptions<EndpointsNorthwindAPI> endpoints;

    public ServizioAPIGenerico(IHttpClientFactory httpClientFactory, IOptions<EndpointsNorthwindAPI> endpoints)
    {
        this.httpClientFactory = httpClientFactory;
        this.endpoints = endpoints;
    }

    public void CancelRequest()
    {
        cancellationTokenSource?.Cancel();
    }

    public async Task<Page<T>?> Get(string Address, string SearchText, int CurrentPageNumber)
    {
        var httpClient = httpClientFactory.CreateClient("NorthWindApi");
        var address = $"{Address}?FilterText={SearchText}&PageNumber={CurrentPageNumber}";
        cancellationTokenSource = new CancellationTokenSource();

        var response = await httpClient.GetAsync(address,
            HttpCompletionOption.ResponseHeadersRead,
             cancellationTokenSource.Token
            );
        if (response.IsSuccessStatusCode)
        {
            if (response.Content is not null)
            {
                var page = await response.Content.ReadFromJsonAsync<Page<T>>();
                return page;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public async Task<T?> GetById(string Address, string Id)
    {
        var httpClient = httpClientFactory.CreateClient("NorthWindApi");
        var address = $"{Address}/{Id}";
        cancellationTokenSource = new CancellationTokenSource();

        var response = await httpClient.GetAsync(address,
            HttpCompletionOption.ResponseHeadersRead,
             cancellationTokenSource.Token
            );
        if (response.IsSuccessStatusCode)
        {
            if (response.Content is not null)
            {
                var x= await response.Content.ReadFromJsonAsync<T>();
                return x;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
