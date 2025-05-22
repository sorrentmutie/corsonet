using Fluxor;

namespace DemoFluxor.State;

public static class Reducers
{
    [ReducerMethod]
    public static CartState ReduceAddItemToCartAction(
        CartState cartState, AddItemToCartAction action)
    {
        var item = action.ItemToAdd;
        if(item is not null)
        {
            cartState.Items.Add(item);
        }        

        return new CartState(
            cartState.Items);
    }
}
