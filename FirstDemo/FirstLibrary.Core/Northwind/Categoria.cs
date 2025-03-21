
using System.ComponentModel.DataAnnotations;

namespace FirstLibrary.Core.Northwind;

public  class Categoria
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(15, ErrorMessage = "Il nome non può superare i 15 caratteri")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "La descrizione è obbligatoria")]
    public string? Descrizione { get; set; }

    public int NumeroProdotti { get; set; }

    public List<Prodotto>? Prodotti { get; set; } 
}
