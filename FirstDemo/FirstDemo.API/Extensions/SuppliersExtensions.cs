using FirstDemo.Data.Models;
using FirstLibrary.Core.DataTypes;
using FirstLibrary.Core.Northwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FirstDemo.API.Extensions;
public static class SuppliersExtensions
{
    public static Expression<Func<Supplier, bool>>? FilterSupplier(string filterText)
    {
        return x => x.CompanyName.Contains(filterText);// || x.Products.Any(p => p.ProductName.Contains(filterText));
    }
}

public static class SuppliersEndpoints
{
    public static async Task<IResult> Estrai([AsParameters] PageParameters pageParameters, NorthwindContext db, IConfiguration configuration)
    {
        int pageSize = 1;
        int pageCount = 1;
        var results = db.Suppliers.Include(s => s.Products).AsQueryable();
        int itemsCount = 0;
        if (configuration != null)
        {
            pageSize = configuration.GetValue<int>("ApiParameters:PageSize");
        }
        if (!string.IsNullOrEmpty(pageParameters.FilterText))
        {
            var predicate = SuppliersExtensions.FilterSupplier(pageParameters.FilterText);
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
        var page = new Page<Fornitore>
        {
            CurrentPage = pageParameters.PageNumber,
            PageCount = pageCount,
            ItemCount = itemsCount,
            SortDirection = pageParameters.SortDirection ?? SortDirection.Ascending,
            SortBy = pageParameters.SortBy,
            Items = await results
                .Skip((pageParameters.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new Fornitore
                {
                    Id = p.SupplierId,
                    Nome = p.CompanyName,
                    Contatto = p.ContactName,
                    Citta = p.City,
                    Indirizzo = p.Address
                }).ToListAsync()
        };
        return Results.Ok(page);
    }
}