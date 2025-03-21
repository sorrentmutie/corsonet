using Microsoft.JSInterop;

namespace FirstDemo.Blazor.UI.Interop;

public class HelloHelper
{
    public string Nome { get; set; }

    public HelloHelper(string nome)
    {
        Nome = nome;
    }

    [JSInvokable]   
    public string SayHello()
    {
        return $"Olá, {Nome}!";
    }
}
