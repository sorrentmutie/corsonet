using Microsoft.JSInterop;

namespace FirstDemo.Blazor.UI.Interop;

public class MyModalInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MyModalInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/FirstDemo.UI.Kit/myModal.js").AsTask());
    }

    public async ValueTask ApriModale(string Id)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("mostraModale", Id);
    }

    public async ValueTask ChiudiModale()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("chiudiModale");
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