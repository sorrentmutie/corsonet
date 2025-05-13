namespace FirstLibrary.Core.Northwind
{
    public class Impiegato : ISearchResultType
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int Id { get; set; }
    }
}
