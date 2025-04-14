using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FirstDemo.BLazor.Server.Data;
using FirstLibrary.Core.Conferenze;
using FirstDemo.BLazor.Server.Services;
using FirstDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using FirstLibrary.Core.Northwind;
using FirstDemo.BLazor.UI.Services;
using FirstDemo.Blazor.UI.DataServices;
using FirstLibrary.Core.Common;
using FirstDemo.Data;
using FirstDemo.Blazor.UI.Services;
using FirstLibrary.Core.Mappe;
using FirstDemo.Blazor.UI.Pages;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IConferenze, GestoreConferenze>();
builder.Services.AddScoped<ITrasformazioneTesto, UppercaseTransformation>();
builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});
builder.Services.AddScoped<ICategorie, ServizioCategorie>();

builder.Services.AddScoped
    <IDataServices<ProdottoListitem, ProdottoDetails, int>, 
     ProdottoDataService<ProdottoListitem, ProdottoDetails>>();

builder.Services.AddScoped
    <IDataServices<CustomerListItem, CustomerDetail, string>,
     CustomersDataService<CustomerListItem, CustomerDetail>>();

builder.Services.AddScoped<IRepository<Product, int>, 
    EFRepository<Product, int>>();
builder.Services.AddScoped<IRepository<Customer, string>,
    EFRepository<Customer, string>>();
builder.Services.AddScoped<IRepository<Order, int>,
    EFRepository<Order, int>>();

builder.Services.AddScoped<DbContext, NorthwindContext>();
builder.Services.AddScoped<IDatiMappa, GestioneMappe>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
