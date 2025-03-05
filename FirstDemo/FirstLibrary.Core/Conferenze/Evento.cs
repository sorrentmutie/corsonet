namespace FirstLibrary.Core.Conferenze;

public class Evento
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string Descrizione { get; set; } = default!;
    public DateTime DataInizio { get; set; }
    public DateTime DataFine { get; set; }
    public required string Luogo { get; set; }
}
