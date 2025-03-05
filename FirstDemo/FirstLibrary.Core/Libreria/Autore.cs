using FirstLibrary.Core.Common;

namespace FirstLibrary.Core.Libreria;

public class Autore: Entity
{
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? SitoWeb { get; set; }
    public List<Libro>? Libri { get; set; }
}