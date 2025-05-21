using FirstDemo.Data.Models;

namespace FirstDemo.Blazor.UI.State;

public class AppState
{
    public void SetSelectedSupplier(string supplier)
    {
        Message = $"Selected supplier: {supplier}";
        SelectedSupplier = supplier;
        //OnChangeSupplier?.Invoke();
        OnChangeMessage?.Invoke();
    }
    public void SetSelectedCustomer(string customer)
    {
        Message = $"Selected customer: {customer}";
        SelectedCustomer = customer;
        //OnChangeCustomer?.Invoke();
        OnChangeMessage?.Invoke();
    }

    //public event Action? OnChangeCustomer;
    //public event Action? OnChangeSupplier;
    public event Action? OnChangeMessage;
    public string SelectedSupplier { get; set; } = default!;
    public string SelectedCustomer { get; set; } = default!;
    public string Message { get; set; } = default!;
}
