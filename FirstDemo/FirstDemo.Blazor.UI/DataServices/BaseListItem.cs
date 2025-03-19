using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices;

public interface BaseListItem<IdType>
{
    public IdType? Id { get; set; }
}
