namespace Aggregate;

public class Id<T>
{
    private T DbId { get; }

    public Id(T dbId)
    {
        DbId = dbId;
    }
}