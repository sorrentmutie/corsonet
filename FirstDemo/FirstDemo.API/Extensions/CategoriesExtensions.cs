using FirstDemo.Data.Models;
using FirstLibrary.Core.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FirstDemo.API.Extensions;

public static class CategoriesExtensions
{
    public static Categoria? ToCategoria(this Category? category)
    {
        if (category == null) return null;
        return new Categoria
        {
            Nome = category.CategoryName,
            Descrizione = category.Description,
            CategoryId = category.CategoryId,
            NumeroProdotti = category.Products.Count,
            Prodotti = category.Products.Select(p => new Prodotto
            {
                Id = p.ProductId,
                Nome = p.ProductName,
                PrezzoUnitario = p.UnitPrice ?? 0,
                Giacenza = p.UnitsInStock ?? 0,
                Fornitore = p.Supplier?.CompanyName ?? "Sconosciuto",

            }).ToList()
        };
    }
}

public static class CategorieEndpoints
{
    public static async Task<IResult> EstraiTutti(NorthwindContext db)
    {
            var categories = await db.Categories
             .Include(c => c.Products)
             .Select(c => new Categoria
             {
                 Nome = c.CategoryName,
                 Descrizione = c.Description,
                 CategoryId = c.CategoryId,
                 NumeroProdotti = c.Products.Count,
                 Prodotti = c.Products.Select(p => new Prodotto
                 {
                     Id = p.ProductId,
                     Nome = p.ProductName,
                     PrezzoUnitario = p.UnitPrice ?? 0,
                     Giacenza = p.UnitsInStock ?? 0,
                    // Fornitore = p.Supplier?.CompanyName ?? "Sconosciuto"
                 }).ToList()
             })
             .ToListAsync();
            return Results.Ok(categories);
    } 

    public static async Task<IResult> EstraiPerId(NorthwindContext db, int id)
    {
        var category = await db.Categories
         .Include(p => p.Products)
             .ThenInclude(p => p.Supplier)
         .Include(p => p.Products)
             .ThenInclude(p => p.OrderDetails)
         .FirstOrDefaultAsync(c => c.CategoryId == id);

        if (category == null) return Results.NotFound();
        return Results.Ok(category.ToCategoria());
    }

    public static async Task<IResult> Crea(NorthwindContext db, Categoria categoria)
    {
        if(categoria is null) return Results.BadRequest("Categoria non valida");
        if(categoria.Nome.Length > 15) 
            return Results.BadRequest("Il nome non può superare i 15 caratteri");

        var category = new Category
        {
            CategoryName = categoria.Nome,
            Description = categoria.Descrizione,
            Products = categoria.Prodotti == null ?
               null : categoria.Prodotti.Select(p => new Product
               {
                   ProductName = p.Nome,
                   UnitPrice = p.PrezzoUnitario,
                   UnitsInStock = p.Giacenza,
                   Supplier = new Supplier { CompanyName = p.Fornitore }
               }).ToList()
        };

        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();

        return Results.Created
            ($"/categories/{category.CategoryId}", category);
    }

    public static async Task<IResult> Cancella(NorthwindContext db, int id)
    {
        if(id <= 0) return Results.BadRequest("Id non valido");
        var category = await db.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        if (category == null) return Results.NotFound();
        if(category.Products.Count > 0)
            return Results.BadRequest("Categoria non vuota");
        db.Categories.Remove(category);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }



    public static async Task<IResult> Modifica(NorthwindContext db, int id, Categoria categoria)
    {
        if (categoria is null) return Results.BadRequest("Categoria non valida");
        if(categoria.Nome is null || categoria.Nome.Length == 0)
            return Results.BadRequest("Il nome è obbligatorio");
        if (categoria.Nome.Length > 15)
            return Results.BadRequest("Il nome non può superare i 15 caratteri");
        if(id <= 0) return Results.BadRequest("Id non valido");
        if(id != categoria.CategoryId) return Results.BadRequest("Id non corrispondente");

        var category = await db.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        if (category == null) return Results.NotFound();

        category.CategoryName = categoria.Nome;
        category.Description = categoria.Descrizione;

        await db.SaveChangesAsync();
        return Results.NoContent();
    }



}
