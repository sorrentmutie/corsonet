using DemoFluxor.State;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace DemoFluxor.Components.Pages
{
    public partial class Items
    {

      
        [Inject] IState<CartState> CartState { get; set; }
        [Inject] IDispatcher Dispatcher { get; set; }

        private string itemName { get; set; } = string.Empty;
        private decimal price { get; set; }

        private void AddItem()
        {
            //var item = new Item { Name = itemName, Price = price };
            //var addItemAction = new AddItemToCartAction(item);
            Dispatcher.Dispatch(new AddItemToCartAction(new Item { Name = itemName, Price = price }));
        }

    }
}
