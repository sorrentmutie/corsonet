
namespace FirstDemo.Blazor.UI.DataServices;

public class CustomerListItem : BaseListItem<string>
{
    public string? Id { get; set; }
    public string RagioneSociale { get; set; } = string.Empty;
    public string Indirizzo { get; set; } = string.Empty;
    public string Citta { get; set; } = string.Empty;
    public string    CAP { get; set; } =string.Empty;
}

public class CustomerDetail : BaseDetails<string>
{
    public string? Id { get ; set ; }
    public string RagioneSociale { get;set; } = string.Empty;
    public int TotOrdini { get; set; }
    public List<OrderListItem> Ordini { get; set; } = new();


}