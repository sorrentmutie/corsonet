using FirstDemo.Blazor.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FirstDemo.Blazor.UI.Interop;

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
        await jSRuntime.InvokeVoidAsync("thirdChart", element, chartType.ToString(),chartData);
    }

    public async Task ShowPie(ElementReference element, ChartPieData chartData)
    {
        await jSRuntime.InvokeVoidAsync("thirdChart", element, ChartType.Pie.ToString(), chartData);
    }

    //public async Task ShowThirdChart(ElementReference element, ChartType chartType)
    //{
    //    await jSRuntime.InvokeVoidAsync("thirdChart", element, chartType.ToString());
    //}


    //public async Task ShowThirdChart(ElementReference element)
    //{
    //    await jSRuntime.InvokeVoidAsync("thirdChart", element);
    //}

    //public async Task ShowSecondChart(ElementReference element)
    //{
    //    await jSRuntime.InvokeVoidAsync("secondChart", element);
    //}

    //public async Task ShowChart(ElementReference element, ChartData chartData, ChartType type)
    //{
    //    await jSRuntime.InvokeVoidAsync("showChart", element, chartData, type.ToString());
    //}

    //public async Task UpdateChart(ElementReference element, ChartData chartData, ChartType type)
    //{
    //    await jSRuntime.InvokeVoidAsync("updateChart", element, chartData, type);
    //}
}
