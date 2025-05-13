using FirstDemo.UI.Kit.DataTypes;

namespace FirstDemo.UI.Kit.Interfaces;
public interface IServizioAPIGenerico<T> where T : class
{
    Task<Page<T>?> Get(string Address, string SearchText, int CurrentPageNumber);
    Task<T?> GetById(string Address, string Id);
    void CancelRequest();
}
