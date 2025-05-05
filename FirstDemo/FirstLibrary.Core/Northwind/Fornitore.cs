using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary.Core.Northwind;
public class Fornitore
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Contatto { get; set; }
    public string? Indirizzo { get; set; }
    public string? Citta { get; set; }

}
