using FirstDemo.API.Extensions;
using FirstDemo.Data.Models;
using FirstLibrary.Core.DataTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});
builder.Services.AddCors(o => o.AddPolicy("Policy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Policy");
var group = app.MapGroup("/categories");

group.MapGet("/", CategorieEndpoints.EstraiTutti)
    .WithName("GetCategories")
    .WithOpenApi();

group.MapGet("/{id}", CategorieEndpoints.EstraiPerId);
//group.MapGet("/search/{name}/page/{page}/results/{results}", CategorieEndpoints.EstraiPerNome);

group.MapPost("/", CategorieEndpoints.Crea);
group.MapDelete("/{id}", CategorieEndpoints.Cancella);
group.MapPut("/{id}", CategorieEndpoints.Modifica);

var productGroup = app.MapGroup("/products");
productGroup.MapGet("/", async ([AsParameters] PageParameters pageParameters, NorthwindContext db) =>
{
    int pageSize = 10;
    int pageCount = 1;
    var results = db.Products.AsQueryable();
    int itemsCount = 0;

    if (!string.IsNullOrEmpty(pageParameters.FilterText))
    {
        var predicate = FilterProduct(pageParameters.FilterText);
        if(predicate != null)
        {
            results = results.Where(predicate);
        }

        itemsCount = results.Count();
        pageCount = (itemsCount + pageSize - 1) / pageSize;
        if(pageParameters.PageNumber > pageCount)
        {
           pageParameters.PageNumber = pageCount;
        }

        if(!string.IsNullOrEmpty(pageParameters.SortBy))
        {
            if (pageParameters.SortDirection == SortDirection.Ascending)
            {
                results = results.OrderBy(x => EF.Property<object>(x, pageParameters.SortBy));
            }
            else
            {
                results = results.OrderByDescending(x => EF.Property<object>(x, pageParameters.SortBy));
            }
        }

    }

    var page = new Page<Product>
    {
        CurrentPage = pageParameters.PageNumber,
        PageCount = pageCount,
        ItemCount = itemsCount,
        SortDirection = pageParameters.SortDirection ?? SortDirection.Ascending,
        SortBy = pageParameters.SortBy,
        Items = await results
            .Skip((pageParameters.PageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()
    }; 
    return Results.Ok(page);
});

Expression<Func<Product, bool>>? FilterProduct(string filterText)
{
    return x => x.ProductName.Contains(filterText);
} 


app.Run();

