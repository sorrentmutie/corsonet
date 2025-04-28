using FirstDemo.Data.Models;
using FirstDemo.Data;
using FirstLibrary.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FirstDemo.BLazor.Server.Services;
using FirstDemo.Blazor.UI.DataServices;
using FirstDemo.Blazor.UI.Services;
using FirstLibrary.Core.Conferenze;
using FirstLibrary.Core.Mappe;
using FirstLibrary.Core.Northwind;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
.AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IData, ServerDataService>();

builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});

builder.Services.AddScoped<DbContext, NorthwindContext>();

builder.Services.AddScoped<IRepository<Product, int>,
    EFRepository<Product, int>>();
builder.Services.AddScoped<IRepository<Customer, string>,
    EFRepository<Customer, string>>();
builder.Services.AddScoped<IRepository<Order, int>,
    EFRepository<Order, int>>();

builder.Services.AddScoped<ICategorie, ServizioCategorie>();

builder.Services.AddScoped
    <IDataServices<ProdottoListitem, ProdottoDetails, int>,
     ProdottoDataService<ProdottoListitem, ProdottoDetails>>();

builder.Services.AddScoped
    <IDataServices<CustomerListItem, CustomerDetail, string>,
     CustomersDataService<CustomerListItem, CustomerDetail>>();

builder.Services.AddScoped<IDatiMappa, GestioneMappe>();

builder.Services.AddScoped<IConferenze, GestoreConferenze>();
builder.Services.AddScoped<ITrasformazioneTesto, UppercaseTransformation>();

builder.Services.AddScoped<IServizioDettagliOrdini, ServizioDettagliOrdini>();

builder.Services.AddScoped<IDashboardData, DashboardDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DemoNet8.Client._Imports).Assembly)
    .AddAdditionalAssemblies(typeof(FirstDemo.Blazor.UI._Imports).Assembly);

app.Run();
