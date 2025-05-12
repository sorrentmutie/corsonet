using FirstDemo.Data.Models;
using FirstLibrary.Core.DataTypes;
using FirstLibrary.Core.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstDemo.API.Extensions;

public static class ProductsExtensions
{
    public static Expression<Func<Product, bool>>? FilterProduct(string filterText)
    {
        return x => x.ProductName.Contains(filterText) || x.Supplier.CompanyName.Contains(filterText);
    }

    public static void RegistrazioneProdotti(this WebApplication app)
    {
        var productGroup = app.MapGroup("/products");
        productGroup.MapGet("/", ProdottiEndpoints.Estrai);
    }
}

public static class ProdottiEndpoints
{
    public static async Task<IResult> Estrai([AsParameters] PageParameters pageParameters, NorthwindContext db, IConfiguration configuration)
    {
        int pageSize = 1;
        int pageCount = 1;
        var results = db.Products.Include(p => p.Supplier).AsQueryable();
        int itemsCount = 0;

        if (configuration != null)
        {
            pageSize = configuration.GetValue<int>("ApiParameters:PageSize");
        }

        if (!string.IsNullOrEmpty(pageParameters.FilterText))
        {
            var predicate = ProductsExtensions.FilterProduct(pageParameters.FilterText);
            if (predicate != null)
            {
                results = results.Where(predicate);
            }

            itemsCount = results.Count();
            pageCount = (itemsCount + pageSize - 1) / pageSize;
            if (pageParameters.PageNumber > pageCount)
            {
                pageParameters.PageNumber = pageCount;
            }

            if (!string.IsNullOrEmpty(pageParameters.SortBy))
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

        var page = new Page<Prodotto>
        {
            CurrentPage = pageParameters.PageNumber,
            PageCount = pageCount,
            ItemCount = itemsCount,
            SortDirection = pageParameters.SortDirection ?? SortDirection.Ascending,
            SortBy = pageParameters.SortBy,
            Items = await results
                .Skip((pageParameters.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new Prodotto
                {
                    Id = p.Id,
                    Nome = p.ProductName,
                    PrezzoUnitario = p.UnitPrice ?? 0,
                    Giacenza = p.UnitsInStock ?? 0,
                    Fornitore = p.Supplier.CompanyName
                })
                .ToListAsync()
        };
        return Results.Ok(page);
    }



}
