using Aggregate;

namespace DDDFramework.Tests;

public sealed class OrderId :Id<Guid>
{
    public OrderId(Guid dbId) : base(dbId)
    {
    }
}