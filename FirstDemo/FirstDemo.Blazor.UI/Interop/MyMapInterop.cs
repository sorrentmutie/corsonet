using Microsoft.JSInterop;

namespace FirstDemo.Blazor.UI.Interop;

public class MyMapInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyMapInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/FirstDemo.Blazor.UI/myMap.js").AsTask());
    }

    public async ValueTask MostraMappa()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("mostraMappa");
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

