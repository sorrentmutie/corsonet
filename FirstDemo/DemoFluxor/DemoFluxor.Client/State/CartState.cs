using Fluxor;
using System.Collections.Immutable;

namespace DemoFluxor.Client.State;

[FeatureState]
public class CartState
{
    public ImmutableArray<Item> Items { get; } =
        ImmutableArray.Create<Item>();

    public CartState(ImmutableArray<Item> itemsInCart)
    {
        Items = itemsInCart;
    }

}
