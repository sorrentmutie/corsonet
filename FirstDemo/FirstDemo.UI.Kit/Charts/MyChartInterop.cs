
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FirstDemo.UI.Kit.Charts;

public class MyChartInterop
{
    private readonly IJSRuntime jSRuntime;

    public MyChartInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task ShowFirstChart()
    {
        await jSRuntime.InvokeVoidAsync("firstChart");
    }

    public async Task ShowSecondChart(string id)
    {
        await jSRuntime.InvokeVoidAsync("secondChart", id);
    }

    public async Task ShowThirdChart(ElementReference element, ChartType chartType, ChartData chartData)
    {
        await jSRuntime.InvokeVoidAsync("thirdChart", element, chartType.ToString(), chartData);
    }

    public async Task ShowPie(ElementReference element, ChartPieData chartData)
    {
        await jSRuntime.InvokeVoidAsync("thirdChart", element, ChartType.Pie.ToString(), chartData);
    }

}
