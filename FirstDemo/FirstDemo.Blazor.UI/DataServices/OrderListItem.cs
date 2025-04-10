using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices;

public class OrderListItem : BaseListItem<int>
{
    public int Id { get; set; }

    public DateTime? OrderDate { get; set; }
    public string ShipName { get; set; } = string.Empty;
}
