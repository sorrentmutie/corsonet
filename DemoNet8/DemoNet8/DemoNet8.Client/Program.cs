using DemoNet8.Client.Services;
using DemoNet8.Core.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IData, MyDataClientService>();

await builder.Build().RunAsync();
