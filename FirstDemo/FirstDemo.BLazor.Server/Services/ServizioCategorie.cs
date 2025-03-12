using FirstDemo.Data.Models;
using FirstLibrary.Core.Northwind;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.BLazor.Server.Services;

public class ServizioCategorie : ICategorie
{
    private readonly NorthwindContext database;

    public ServizioCategorie(NorthwindContext database)
    {
        this.database = database;
    }

    public async Task CreateCategoria(Categoria categoria)
    {
        var category = new Category
        {
            CategoryName = categoria.Nome,
            Description = categoria.Descrizione,
            //Products = new List<Product>()
            //{
            //    new Product { ProductName = "Prodotto 1", UnitPrice = 10 },
            //    new Product { ProductName = "Prodotto 2", UnitPrice = 20 },
            //}
        };
        await database.Categories.AddAsync(category);
        await database.SaveChangesAsync();
    }

    public async Task DeleteCategoria(int id)
    {
        var category = database.Categories.Find(id);
        if (category is not null)
        {
            database.Categories.Remove(category);
            await database.SaveChangesAsync();
        }
    }

    public async Task<Categoria?> GetCategoria(int id)
    {
        var category = await database.Categories
            .AsNoTracking()
            .Include(p => p.Products)
                .ThenInclude(p => p.Supplier)
            .Include(p => p.Products)
                .ThenInclude(p => p.OrderDetails)
            .FirstOrDefaultAsync(x => x.CategoryId == id);
        return category == null ? null : new Categoria
        {
            CategoryId = category.CategoryId,
            Descrizione = category.Description,
            Nome = category.CategoryName,
            NumeroProdotti = category.Products.Count,
            Prodotti = category.Products.Select(p => new Prodotto
            {
                Id = p.ProductId,
                Nome = p.ProductName,
                PrezzoUnitario = p.UnitPrice,
                Giacenza = p.UnitsInStock,
                ScortaMinima = p.ReorderLevel,
                Fornitore = p.Supplier?.CompanyName,
                NumeroOrdini = p.OrderDetails.Count
            }).ToList()
        };
    }

    public async Task<IEnumerable<Categoria>> GetCategorie()
    {
        return await database.Categories
            .Select(c => new Categoria
            {
                CategoryId = c.CategoryId,
                Descrizione = c.Description,
                Nome = c.CategoryName,
                NumeroProdotti = c.Products.Count
            })
            .OrderBy(c => c.Nome)
            .ToListAsync();
    }

    public async Task UpdateCategoria(Categoria categoria)
    {
        var dbCategory = await database.Categories.FindAsync(categoria.CategoryId);
        if (dbCategory is not null)
        {
            //database.Entry(dbCategory).State = EntityState.Modified;

            dbCategory.CategoryName = categoria.Nome;

            if (categoria.Descrizione is not null)
                dbCategory.Description = categoria.Descrizione;


            await database.SaveChangesAsync();
        }
    }
}
