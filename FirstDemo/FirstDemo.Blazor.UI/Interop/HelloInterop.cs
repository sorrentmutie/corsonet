using Microsoft.JSInterop;

namespace FirstDemo.Blazor.UI.Interop;

public class HelloInterop: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? obj;

    public HelloInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task  CallHelloHelper(string nome)
    {
        var helper = new HelloHelper(nome);
        obj = DotNetObjectReference.Create(helper);

        await jSRuntime.InvokeVoidAsync("ola", obj);
    }

    public void Dispose()
    {
        obj?.Dispose();
    }
}
