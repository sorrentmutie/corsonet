using FirstLibrary.Core.Conferenze;

namespace FirstDemo.BLazor.Server.Services;

public class GestoreConferenzeOracle : IConferenze
{
    public List<Evento>? EstraiEventiFuturi()
    {
        throw new NotImplementedException();
    }

    public Task<List<Evento>> EstraiEventiFuturiAsync()
    {
        throw new NotImplementedException();
    }

    public List<Evento>? EstraiEventiPassati()
    {
        throw new NotImplementedException();
    }

    public Task<List<Evento>> EstraiEventiPasstiAsync()
    {
        throw new NotImplementedException();
    }
}

public class GestoreConferenze: IConferenze
{
    public List<Evento>? EstraiEventiFuturi()
    {
        return new List<Evento>()
        {
            new Evento(){Id=1, Nome="Evento 1", DataInizio=DateTime.Now, Luogo = "Napoli" },
            new Evento(){Id=2, Nome="Evento 2", DataInizio=DateTime.Now.AddDays(1), Luogo = "Milano"},
            new Evento(){Id=3, Nome="Evento 3", DataInizio=DateTime.Now, Luogo = "Verona"},
            new Evento(){Id=4, Nome="Evento 4", DataInizio=DateTime.Now, Luogo = "Venezia"},
            new Evento(){Id=5, Nome="Evento 5", DataInizio=DateTime.Now, Luogo = "Roma"}
        };
    }

    public async Task<List<Evento>> EstraiEventiFuturiAsync()
    {
        await Task.Delay(1000);
        return new List<Evento>()
        {
            new Evento(){Id=1, Nome="Evento 1", DataInizio=DateTime.Now, Luogo = "Napoli" },
            new Evento(){Id=2, Nome="Evento 2", DataInizio=DateTime.Now.AddDays(1), Luogo = "Milano"},
            new Evento(){Id=3, Nome="Evento 3", DataInizio=DateTime.Now, Luogo = "Verona"},
            new Evento(){Id=4, Nome="Evento 4", DataInizio=DateTime.Now, Luogo = "Venezia"},
            new Evento(){Id=5, Nome="Evento 5", DataInizio=DateTime.Now, Luogo = "Roma"}
        };
    }

    public List<Evento>? EstraiEventiPassati()
    {
        return new List<Evento>()
        {
            new Evento(){Id=6, Nome="Evento 6", DataInizio=DateTime.Now.AddDays(-1), Luogo = "Napoli" },
            new Evento(){Id=7, Nome="Evento 7", DataInizio=DateTime.Now.AddDays(-2), Luogo = "Milano"},
            new Evento(){Id=8, Nome="Evento 8", DataInizio=DateTime.Now.AddDays(-3), Luogo = "Verona"},
            new Evento(){Id=9, Nome="Evento 9", DataInizio=DateTime.Now.AddDays(-4), Luogo = "Venezia"},
            new Evento(){Id=10, Nome="Evento 10", DataInizio=DateTime.Now.AddDays(-5), Luogo = "Roma"}
        };
    }

    public async Task<List<Evento>> EstraiEventiPasstiAsync()
    {
        await Task.Delay(1000);
        return new List<Evento>()
        {
            new Evento(){Id=6, Nome="Evento 6", DataInizio=DateTime.Now.AddDays(-1), Luogo = "Napoli" },
            new Evento(){Id=7, Nome="Evento 7", DataInizio=DateTime.Now.AddDays(-2), Luogo = "Milano"},
            new Evento(){Id=8, Nome="Evento 8", DataInizio=DateTime.Now.AddDays(-3), Luogo = "Verona"},
            new Evento(){Id=9, Nome="Evento 9", DataInizio=DateTime.Now.AddDays(-4), Luogo = "Venezia"},
            new Evento(){Id=10, Nome="Evento 10", DataInizio=DateTime.Now.AddDays(-5), Luogo = "Roma"}
        };
    }
}
