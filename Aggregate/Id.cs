namespace Aggregate;

public record Id<T>
{
    private T DbId { get; }

    public Id(T dbId)
    {
        DbId = dbId;
    }
}