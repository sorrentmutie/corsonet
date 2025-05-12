using FirstLibrary.Core.Configurations;
using FirstLibrary.Core.DataTypes;
using Microsoft.Extensions.Options;

namespace FirstDemo.BLazor.Server.Services;

public class ServizioAPIIMpiegati : IServizioAPIImpiegati
{

    private readonly IHttpClientFactory httpClientFactory;
    private CancellationTokenSource? cancellationTokenSource;
    private readonly IOptions<EndpointsNorthwindAPI> endpoints;

    public ServizioAPIIMpiegati(IHttpClientFactory httpClientFactory, IOptions<EndpointsNorthwindAPI> endpoints)
    {
        this.httpClientFactory = httpClientFactory;
        this.endpoints = endpoints;
    }

    public void CancelRequest()
    {
        cancellationTokenSource?.Cancel();
    }

    public async Task<Page<Impiegato>?> GetImpiegati(string SearchText, int CurrentPageNumber)
    {
        var httpClient = httpClientFactory.CreateClient("NorthWindApi");
        //$"/employees?FilterText={SearchText}&PageNumber={CurrentPageNumber}
        var address = $"{endpoints.Value.Impiegati}FilterText={SearchText}&PageNumber={CurrentPageNumber}"; 
        cancellationTokenSource = new CancellationTokenSource();

        // await Task.Delay(3000);
        var response = await httpClient.GetAsync(address,
            HttpCompletionOption.ResponseHeadersRead,
             cancellationTokenSource.Token
            );
        if (response.IsSuccessStatusCode)
        {
            if (response.Content is not null)
            {
                var page = await response.Content.ReadFromJsonAsync<Page<Impiegato>>();
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
}
  
