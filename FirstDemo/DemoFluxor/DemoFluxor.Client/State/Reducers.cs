using Fluxor;

namespace DemoFluxor.Client.State;

public static class Reducers
{
    [ReducerMethod]
    public static CartState ReduceAddItemToCartAction(
        CartState cartState, AddItemToCartAction action)
    {
        return new CartState(
            cartState.Items.Add(action.ItemToAdd));
    }
}
