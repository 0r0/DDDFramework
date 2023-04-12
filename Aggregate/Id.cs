namespace Aggregate;

public class Id<T> : ValueObject
{
    public Id(T dbId)
    {
        DbId = dbId;
    }

    public T DbId { get; }
}