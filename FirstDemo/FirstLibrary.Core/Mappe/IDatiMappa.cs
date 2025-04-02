namespace FirstLibrary.Core.Mappe;
public interface IDatiMappa
{
    Task<List<ParametriMappa>> GetParametriMappaAsync();
}
