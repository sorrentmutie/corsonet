namespace FirstLibrary.Core.Conferenze;

public interface  IConferenze
{
    List<Evento>? EstraiEventiFuturi();
    List<Evento>? EstraiEventiPassati();
    Task<List<Evento>> EstraiEventiFuturiAsync();
    Task<List<Evento>> EstraiEventiPasstiAsync();
}
