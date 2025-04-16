
namespace FirstDemo.BLazor.Server.Services;
public class DashboardDataService : IDashboardData
{
    NorthwindContext database;
    public DashboardDataService(NorthwindContext northwindContext)
    {
        database = northwindContext;
    }

    public Task<CardClienteMigliore?> ClienteMigliore()
    {
        var cliente = database.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .GroupBy(o => o.Customer)
            .Select(g => new CardClienteMigliore
            {
                Id = g.Key.Id ?? string.Empty,
                NomeCliente = g.Key.CompanyName,
                Totale = g.Sum(o => o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity))
            })
            .OrderByDescending(c => c.Totale).FirstOrDefaultAsync();

        return cliente;
    }

    public Task<CardProdottoPiuVenduto?> ProdottoPiuVenduto()
    {
        var articolo = database.OrderDetails
            .Include(od => od.Product)
            .GroupBy(od => od.Product)
            .Select(g => new CardProdottoPiuVenduto
            {
                NomeProdtto = g.Key.ProductName,
                Quantita = g.Sum(od => od.Quantity)
            })
            .OrderByDescending(p => p.Quantita).FirstOrDefaultAsync();

        return articolo;
    }

    public async Task<CardUltimoOrdine?> UltimoOrdine()
    {
        var ordine = await database.Orders
            .Include(o=>o.Customer)
            .Include(o => o.OrderDetails)
            .OrderByDescending(o => o.OrderDate).FirstOrDefaultAsync();
        if (ordine is not null)
        {
            return new CardUltimoOrdine
            {
                Id = ordine.Id,
                NomeCliente = ordine.Customer?.CompanyName ?? string.Empty,
                Totale = ordine.OrderDetails.Sum(od => od.UnitPrice * od.Quantity)
            };
        }
        else
        {
            return null;
        }
    }
}
