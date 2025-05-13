namespace FirstDemo.UI.Kit.DataTypes;

public class Page<ListItemType>
{
    public int ItemCount { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; } 

    public string? SortBy { get; set; } 
    public SortDirection SortDirection { get; set; } 
    public List<ListItemType>? Items { get; set; }
}
