using Aggregate;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public partial class Order : AggregateRoot<OrderId>
{
    public bool IsActive { get; private set; }

    public static async Task<Order> Create(OrderArgs orderArgs, IOrderService orderService)
    {
        throw new NotImplementedException();
    }

    public async Task Placed(OrderArgs orderArgs, IOrderService service)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatedInfo(OrderArgs orderArgs, IOrderService service)
    {
    throw new NotImplementedException();
    }
}