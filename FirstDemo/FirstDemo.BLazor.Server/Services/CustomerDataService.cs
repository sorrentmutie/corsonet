using FirstDemo.Blazor.UI.DataServices;
using FirstDemo.Data.Models;
using FirstLibrary.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.BLazor.Server.Services
{
    public class CustomersDataService<ListItemType, DetailsType>
    : IDataServices<CustomerListItem, CustomerDetail, string>
    where ListItemType : BaseListItem<string>
    where DetailsType : BaseDetails<string>
    {

        private readonly IRepository<Customer, string> repository;
        private readonly IRepository<Order, int> orderRepository;

        public CustomersDataService(IRepository<Customer, string> repository, IRepository<Order, int> orderRepo)
        {
            this.repository = repository;
            this.orderRepository = orderRepo;
        }


        public Task CreateAsync(CustomerDetail details)
        {
            var entity = new Customer
            {
                Id = details.Id,
                CompanyName = details.RagioneSociale

            };
            return repository.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<Page<CustomerListItem, string>> GetAllAsync()
        {
            var data = await repository.GetAll()
            .Select(x => new CustomerListItem
            {
                Id = x.Id,
                RagioneSociale = x.CompanyName,
                Indirizzo = x.Address,
                Citta = x.City,
                CAP = x.PostalCode

            }).ToListAsync();
            return new Page<CustomerListItem, string>
            {
                TotalItems = data.Count,
                Items = data
            };
        }

        public async Task<CustomerDetail?> GetAsync(string id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x is null)
            {
                return null;
            }


            var elencoOrdini = orderRepository.GetAll().Where(x => x.CustomerId == id);

            return new CustomerDetail
            {
                Id = x.Id,
                RagioneSociale = x.CompanyName,
                TotOrdini = elencoOrdini.Count(),
                Ordini = elencoOrdini.Select(o => new OrderListItem()
                { Id = o.Id, OrderDate = o.OrderDate, ShipName = o.ShipName }).ToList()
            };
        }

        public async Task UpdateAsync(CustomerDetail details)
        {
            var entity = new Customer
            {
                Id = details.Id,
                CompanyName = details.RagioneSociale
            };
            await repository.UpdateAsync(entity);
        }
    }
}
