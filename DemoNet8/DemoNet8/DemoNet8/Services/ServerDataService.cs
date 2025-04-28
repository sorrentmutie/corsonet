
namespace DemoNet8.Services;

public class ServerDataService : IData
{
    public async Task<string> GetDataAsync()
    {
        await Task.Delay(1000); // Simulate a delay for data fetching
        return "Data from server";
    }
}
