namespace FirstLibrary.Core.Northwind;

public class Prodotto
{
    public int Id { get; set; }

    public required string Nome { get; set; }

   //  public int? SupplierId { get; set; }

    public decimal? PrezzoUnitario { get; set; }

    public short? Giacenza { get; set; }

    public short? ScortaMinima { get; set; }

    public string? Fornitore { get; set; }

    public int NumeroOrdini { get; set; }

}
