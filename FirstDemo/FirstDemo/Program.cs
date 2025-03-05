using FirstLibrary.Core.Common;

Console.WriteLine("Ciao, mondo!");
var libro = new Libro { Titolo = "Il milione"
   // Autori = new List<Autore> { new Autore { Nome = "Marco", Cognome = "Polo" } }
};
// libro.Titolo = "Il milardo!";
Console.WriteLine(libro.Titolo);

//Libro secondoLibro = new() { Titolo = "Prova" };

//if (libro.Autori == null)
//{
//    libro.Autori = new List<Autore>();
//}

//foreach (var autore in libro.Autori)
//{
//    Console.WriteLine(autore.Nome);
//}

//var e1 = new GenericEntity<int> { Id = 1 };
//var e2 = new GenericEntity<string> { Id = "1" };    

var libreria = new Libreria() { Nome = "Libreria Comunale" };
libreria.AggiungiLibro(libro);


