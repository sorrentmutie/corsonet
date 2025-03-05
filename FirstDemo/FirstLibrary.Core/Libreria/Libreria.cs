namespace FirstLibrary.Core.Libreria;

public class Libreria
{
    private List<Libro> libri = new();
    public required string Nome { get; set; }


    public void AggiungiLibro(Libro libro)
    {
        libri.Add(libro);
    }

    public void StampaElencoLibri()
    {
        libri.StampaElencoLibri();
    }

    public List<Libro> CercaLibri(string  titolo)
    {
        return libri.CercaLibri(titolo);
    }
}
