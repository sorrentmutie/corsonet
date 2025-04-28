using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices
{
    public class OrderSummary
    {
        public int OrderId { get; set; }
        public decimal Totale { get; set; }
        public List<OrderDetailListItem> Dettagli { get; set; } = new();
    }
}
