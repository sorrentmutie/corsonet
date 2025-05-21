using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstDemo.Blazor.UI.State;

public class NotifyMessage : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string message = default!;

    public string Message
    {
        get => message;
        set
        {
            if (message != value)
            {
                message = value;
                OnPropertyChanged();
            }
        }
    }

    protected virtual void OnPropertyChanged(
        [CallerMemberName] string? propertyName = default)
            => PropertyChanged?.Invoke(this, new(propertyName));
}
