

namespace FirstDemo.Blazor.UI.Models;

public class ChartPieData
{
    public required List<string> Labels { get; set; }
    public required List<int> Series { get; set; }
}
