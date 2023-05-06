using Aggregate;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public partial class Order : AggregateRoot<OrderId>
{
public bool IsActive { get; private set; }
}