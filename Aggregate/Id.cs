namespace Aggregate;

public class Id<T> :ValueObject
{
    public T DbId { get; }

    public Id(T dbId)
    {
        DbId = dbId;
    }
}