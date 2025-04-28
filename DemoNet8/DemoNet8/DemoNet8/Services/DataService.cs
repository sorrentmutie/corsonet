using FirstDemo.Blazor.UI.DataServices;
using FirstDemo.Data.Models;
using FirstLibrary.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.BLazor.Server.Services;

public class ProdottoDataService<ListItemType, DetailsType>
    : IDataServices<ProdottoListitem, ProdottoDetails, int>
    where ListItemType : BaseListItem<int>
    where DetailsType : BaseDetails<int>
{
    private readonly IRepository<Product, int> repository;

    public ProdottoDataService(IRepository<Product,int> repository)
    {
        this.repository = repository;
    }

    public Task CreateAsync(ProdottoDetails details)
    {
        var entity = new Product
        {
            ProductName = details.Nome,
            UnitPrice = details.PrezzoUnitario,
            UnitsInStock = details.Giacenza,
            Discontinued = false
        };
        return  repository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<Page<ProdottoListitem, int>> GetAllAsync()
    {
        var data = await repository.GetAll()
            .Select(x => new ProdottoListitem
            {
                Giacenza = x.UnitsInStock,
                Nome = x.ProductName,
                NumeroOrdini = x.OrderDetails.Count,
                PrezzoUnitario = x.UnitPrice,
                 ScortaMinima = x.ReorderLevel ?? 0,
                Id = x.Id
            }).ToListAsync();
        return new Page<ProdottoListitem, int>
        {
            TotalItems = data.Count,
            Items = data
        };


    }

    public async Task<ProdottoDetails?> GetAsync(int id)
    {
        var x = await repository.GetByIdAsync(id);
        if (x is null)
        {
            return null;
        }
        return new ProdottoDetails
        {
            Id = x.Id,
            Nome = x.ProductName,
            ScortaMinima = x.ReorderLevel ?? 0,
            PrezzoUnitario = x.UnitPrice ?? 0,
            Giacenza = x.UnitsInStock ?? 0,
            Fornitore = x.Supplier?.CompanyName ?? "Sconosciuto"
        };

    }

    public async Task UpdateAsync(ProdottoDetails details)
    {
        var entity = new Product
        {
            Id = details.Id,
            ProductName = details.Nome,
            UnitPrice = details.PrezzoUnitario,
            UnitsInStock = details.Giacenza,
            ReorderLevel = details.ScortaMinima,
            Discontinued = false
        };
        await repository.UpdateAsync(entity);

    }

}
