namespace Aggregate;

public class Id<T>
{
    public T DbId { get; }

    public Id(T dbId)
    {
        DbId = dbId;
    }
}