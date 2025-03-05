namespace FirstLibrary.Core.Common;

public class Entity
{
    public int Id { get; set; }
}

public class GenericEntity<T>
{
    public T Id { get; set; } = default!;
}

