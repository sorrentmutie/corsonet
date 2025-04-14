
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Blazor.UI.DataServices;

public class CustomerListItem : BaseListItem<string>
{
    public string? Id { get; set; }
    public string RagioneSociale { get; set; } = string.Empty;
    public string Indirizzo { get; set; } = string.Empty;
    public string Citta { get; set; } = string.Empty;
    public string CAP { get; set; } = string.Empty;
}

public class CustomerDetail : BaseDetails<string>
{
    [Required(ErrorMessage = "Id non può essrre vuoto")]
    [MaxLength(5)]
    public string? Id { get; set; }
    [Required(ErrorMessage = "La ragione sociale non può essere vuota")]
    public string RagioneSociale { get; set; } = string.Empty;
    [Required(ErrorMessage = "L'indirizzo non può essere vuoto")]
    public string Indirizzo { get; set; } = string.Empty;
    public int TotOrdini { get; set; }
    public List<OrderListItem> Ordini { get; set; } = new();


}