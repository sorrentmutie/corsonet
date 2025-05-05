using System.Diagnostics.CodeAnalysis;

namespace FirstLibrary.Core.DataTypes;

public enum SortDirection
{
    Ascending,
    Descending
}

public class PageParameters 
{
    public string FilterText { get; set; }
    public int PageNumber { get; set; }
    public string? SortBy { get; set; }
    public SortDirection? SortDirection { get; set; }
}
