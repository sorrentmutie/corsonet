using DemoNet8.Client.Services;
using DemoNet8.Core.Interfaces;
using FirstDemo.Blazor.UI.Services;
using FirstLibrary.Core.Mappe;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IData, MyDataClientService>();
builder.Services.AddScoped<IDatiMappa, GestioneMappe>();

await builder.Build().RunAsync();
