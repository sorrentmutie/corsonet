using FirstLibrary.Core.Common;

namespace FirstLibrary.Core.Libreria;

public class Libro: Entity
{
    public required string Titolo { get; set; }
    public string? ISBN { get; init; }
   // public List<Autore> Autori { get; set; } = new();
    public List<Autore>? Autori { get; set; }



    //public Libro(string titolo)
    //{
    //    Titolo = titolo;
    //}

    //public Libro()
    //{
    //}
}
