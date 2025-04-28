using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices
{
    public class OrderDetailListItem
    {
        public int OrderId { get; set; }
        public string NomeProdotto { get; set; } = string.Empty;
        public string NomeFornitore { get; set; } = string.Empty;
        public int Quantita { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public decimal Sconto { get; set; }
        public string CategoriaProdotto { get; set; } = string.Empty;
        public decimal Importo
        {
            get
            {
                return PrezzoUnitario * Quantita * (1 - Sconto);
            }
        }
    }
}
