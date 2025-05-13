using Microsoft.JSInterop;

namespace  FirstDemo.UI.Kit.Maps;
public class MyMapInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyMapInterop(IJSRuntime jsRuntime)
    {

        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/FirstDemo.UI.Kit/MyMapInterop.js").AsTask());
    }

    public async ValueTask MostraMappa(string id, float latitudine, float longitudine, int zoom)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("MostraMappa", id, latitudine, longitudine, zoom);
    }

    public async ValueTask AggiornaMappa(string id, float latitudine, float longitudine, int zoom)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("AggiornaCoordinate",id, latitudine, longitudine, zoom);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
