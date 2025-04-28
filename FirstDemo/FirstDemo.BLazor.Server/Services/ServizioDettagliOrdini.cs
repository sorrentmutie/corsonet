namespace FirstDemo.BLazor.Server.Services;

public class ServizioDettagliOrdini : IServizioDettagliOrdini
{
    private readonly NorthwindContext database;

    public ServizioDettagliOrdini(NorthwindContext database)
    {
        this.database = database;
    }

    public async Task<OrderSummary> GetDettagliOrdine(int id)
    {
        OrderSummary res = new OrderSummary();
        res.OrderId = id;
        var dettagli = await database.OrderDetails
            .AsNoTracking()
            .Include(p => p.Product)
                   .ThenInclude(p => p.Supplier)
            .Include(p => p.Product)
                   .ThenInclude(p => p.Category)
            .Where(x => x.OrderId == id).ToListAsync();

        if (dettagli != null)
        {
            List<OrderDetailListItem> lstOrdDet = new List<OrderDetailListItem>();
            foreach (var item in dettagli)
            {
                lstOrdDet.Add(new OrderDetailListItem
                {
                    OrderId = item.OrderId,
                    NomeProdotto = item.Product?.ProductName ?? "",
                    NomeFornitore = item.Product?.Supplier?.CompanyName ?? "",
                    PrezzoUnitario = item.UnitPrice,
                    Quantita = item.Quantity,
                    CategoriaProdotto = item.Product?.Category?.CategoryName ?? "",
                    Sconto = (decimal)item.Discount
                });
            }

            res.Dettagli = lstOrdDet;
            res.Totale = lstOrdDet.Sum(x => x.PrezzoUnitario * x.Quantita * (1 - x.Sconto));
            // Process the details as needed
        }
        return res;
    }
}
