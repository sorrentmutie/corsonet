using FirstDemo.API.Extensions;
using FirstDemo.Data.Models;
using FirstLibrary.Core.Northwind;
using Microsoft.EntityFrameworkCore;

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


app.Run();

