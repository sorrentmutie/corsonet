using DemoNet8.Core.Interfaces;

namespace DemoNet8.Client.Services;

public class MyDataClientService : IData
{
    public async Task<string> GetDataAsync()
    {
        await Task.Delay(3000);
        return "Data from Client Service"; // Simulate a delay for data fetching
    }
}
