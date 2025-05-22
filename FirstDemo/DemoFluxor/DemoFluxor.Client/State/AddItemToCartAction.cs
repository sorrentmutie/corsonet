namespace DemoFluxor.Client.State;

public class AddItemToCartAction
{
    public Item ItemToAdd { get; }
    public AddItemToCartAction(Item item)
    {
        ItemToAdd = item;
    }
}
