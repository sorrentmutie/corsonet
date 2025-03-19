namespace FirstDemo.Blazor.UI.DataServices;

public interface BaseDetails<IdType>
{
    public IdType? Id { get; set; }
}
