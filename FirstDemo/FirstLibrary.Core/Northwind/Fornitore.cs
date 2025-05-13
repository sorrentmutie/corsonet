namespace FirstLibrary.Core.Northwind;
public class Fornitore : ISearchResultType
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Contatto { get; set; }
    public string? Indirizzo { get; set; }
    public string? Citta { get; set; }

}
