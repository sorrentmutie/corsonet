using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices;

public class ProdottoListitem: BaseListItem<int>
{
    public string Nome { get; set; } = string.Empty;
    public decimal? PrezzoUnitario { get; set; }
    public short? Giacenza { get; set; }
    public string? Fornitore { get; set; } = string.Empty;
    public int NumeroOrdini { get; set; }
    public int Id { get; set; }
}

public class ProdottoDetails : BaseDetails<int>
{
    public string Nome { get; set; } = string.Empty;
    public decimal? PrezzoUnitario { get; set; }
    public short? Giacenza { get; set; }
    public short? ScortaMinima { get; set; }
    public string? Fornitore { get; set; } = string.Empty;
    public int NumeroOrdini { get; set; }
    public int Id { get; set; }
}
