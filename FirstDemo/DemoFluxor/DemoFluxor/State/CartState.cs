using Fluxor;
using System.Collections.Immutable;

namespace DemoFluxor.State;

[FeatureState]
public class CartState
{
    public List<Item> Items { get; } =
        new();


    public CartState()
    {

    } // For serialization only

    public CartState(List<Item> itemsInCart)
    {
        Items = itemsInCart;
    }

}
