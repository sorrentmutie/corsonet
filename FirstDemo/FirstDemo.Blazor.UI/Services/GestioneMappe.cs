using FirstLibrary.Core.Mappe;

namespace FirstDemo.Blazor.UI.Services;

public class GestioneMappe : IDatiMappa
{

    public async Task<List<ParametriMappa>> GetParametriMappaAsync()
    {
        List<ParametriMappa> parametriMappa = new();
        parametriMappa.Add(new ParametriMappa { Id = "Mappa1", Latitudine = -45, Longitudine = 45, Zoom = 13 });
        parametriMappa.Add(new ParametriMappa { Id = "Mappa2", Latitudine = 45, Longitudine = 12, Zoom = 13 });
        parametriMappa.Add(new ParametriMappa { Id = "Mappa3", Latitudine = 0, Longitudine = 0, Zoom = 1 });
        await Task.Delay(3000);
        return parametriMappa;
    }
}
