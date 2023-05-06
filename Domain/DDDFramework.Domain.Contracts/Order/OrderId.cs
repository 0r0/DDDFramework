using Aggregate;

namespace DDDFramework.Domain.Contracts.Order;

public sealed class OrderId :Id<Guid>
{
    public OrderId(Guid dbId) : base(dbId)
    {
    }

    public static OrderId New() => new OrderId(Guid.NewGuid());
   
}