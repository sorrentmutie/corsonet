namespace FirstLibrary.Core.Common;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
