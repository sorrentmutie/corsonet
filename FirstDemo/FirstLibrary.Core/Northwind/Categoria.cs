
namespace FirstLibrary.Core.Northwind;

public  class Categoria
{
    public int CategoryId { get; set; }

    public required string Nome { get; set; }

    public string? Descrizione { get; set; }

    public int NumeroProdotti { get; set; }
}
