
namespace FirstDemo.Blazor.UI.Models;

public class ChartData
{
    public required List<string> Labels { get; set; }
    public required List<List<int>> Series { get; set; }
}
