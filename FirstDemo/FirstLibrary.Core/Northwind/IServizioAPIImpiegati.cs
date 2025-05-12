using FirstLibrary.Core.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLibrary.Core.Northwind
{
    public interface IServizioAPIImpiegati
    {
        Task<Page<Impiegato>?> GetImpiegati(string SearchText, int CurrentPageNumber);
        void CancelRequest();
    }
}
