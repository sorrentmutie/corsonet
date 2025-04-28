using FirstLibrary.Core.Northwind;

namespace FirstDemo.Blazor.UI.DataServices;

public interface IDashboardData
{
    Task<CardUltimoOrdine?> UltimoOrdine();

    Task<CardClienteMigliore?> ClienteMigliore();
    Task<CardProdottoPiuVenduto?> ProdottoPiuVenduto();
}
