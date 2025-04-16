
namespace FirstDemo.Blazor.UI.DataServices;
public interface IServizioDettagliOrdini
    {
        Task<OrderSummary> GetDettagliOrdine(int id);
    }
