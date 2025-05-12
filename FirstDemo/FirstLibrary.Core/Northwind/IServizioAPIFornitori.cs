
using FirstLibrary.Core.DataTypes;
using FirstLibrary.Core.Northwind;

namespace FirstDemo.BLazor.Server.Services
{
    public interface IServizioAPIFornitori
    {
        Task<Page<Fornitore>?> GetFornitori(string SearchText, int CurrentPageNumber);
        void CancelRequest();
    }
}