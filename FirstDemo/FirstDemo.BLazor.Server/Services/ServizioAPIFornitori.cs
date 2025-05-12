using FirstLibrary.Core.DataTypes;

namespace FirstDemo.BLazor.Server.Services;

public class ServizioAPIFornitori : IServizioAPIFornitori
{
    private readonly IHttpClientFactory httpClientFactory;
    private CancellationTokenSource? cancellationTokenSource;

    public ServizioAPIFornitori(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public void CancelRequest()
    {
        cancellationTokenSource?.Cancel();
    }

    public async Task<Page<Fornitore>?> GetFornitori(string SearchText, int CurrentPageNumber)
    {
        var httpClient = httpClientFactory.CreateClient("NorthWindApi");
        var address = $"/suppliers?FilterText={SearchText}&PageNumber={CurrentPageNumber}";
        cancellationTokenSource = new CancellationTokenSource();

        await Task.Delay(30000);
        var response = await httpClient.GetAsync(address,
            HttpCompletionOption.ResponseHeadersRead,
             cancellationTokenSource.Token
            );
        if(response.IsSuccessStatusCode)
        {
            if(response.Content is not null)
            {
                var page = await response.Content.ReadFromJsonAsync<Page<Fornitore>>();
                return page;
            }
            else
            {
                return null;
            }
        } else
        {
            return null;
        }
    }


}
