namespace FirstLibrary.Core.Libreria;

public static class EstensioniLibreria
{
    public static void StampaElencoLibri(this List<Libro> libri)
    {
        foreach (var libro in libri)
        {
            Console.WriteLine(libro.Titolo);
        }
    }

    public static List<Libro> CercaLibri(this List<Libro> libri, string titolo)
    {
        return libri.Where(l => l.Titolo.Contains(titolo)).ToList();
    }

}
