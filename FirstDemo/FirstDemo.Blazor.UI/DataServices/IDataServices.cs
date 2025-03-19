using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Blazor.UI.DataServices;

public interface IDataServices<ListItemType, DetailsType, IdType>
    where ListItemType : BaseListItem<IdType>
{
    Task<Page<ListItemType, IdType>> GetAllAsync();
    Task<DetailsType?> GetAsync(IdType id); 
    Task CreateAsync(DetailsType details);
    Task UpdateAsync(DetailsType details);
    Task DeleteAsync (IdType id);
}

public class Page<ListItemType, IdType>
    where ListItemType : BaseListItem<IdType>
{
    public List<ListItemType>? Items { get; set; }
    public int TotalItems { get; set; }
}