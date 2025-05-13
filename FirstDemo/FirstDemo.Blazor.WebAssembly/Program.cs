using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FirstDemo.Blazor.WebAssembly;
using FirstLibrary.Core.Northwind;
using FirstDemo.Blazor.WebAssembly.Services;
using FirstDemo.Blazor.UI;
using FirstDemo.BLazor.Server.Services;
using FirstLibrary.Core.Conferenze;
using FirstDemo.UI.Kit.Maps;
using FirstDemo.Blazor.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICategorie, ServizioWebCategorie>();
builder.Services.AddScoped<IConferenze, GestoreConferenze>();
builder.Services.AddScoped<ITrasformazioneTesto, UppercaseTransformation>();
builder.Services.AddScoped<IDatiMappa, GestioneMappe>();


await builder.Build().RunAsync();
