using Aggregate;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public partial class Order : AggregateRoot<OrderId>
{
    protected Task CompletionTask;
    public bool IsActive { get; private set; }

    public Order()
    {
    }

    public Order(OrderArgs orderArgs, IOrderService service)
    {
        //todo! add related guards here
        CompletionTask = Task.WhenAll();

        ApplyAndPublish(new OrderCreated(
            id: orderArgs.Id,
            title: orderArgs.Title,
            isActive: orderArgs.IsActive,
            orderNumber: orderArgs.OrderNumber
        ));
    }

    public static async Task<Order> Create(OrderArgs orderArgs, IOrderService orderService)
    {
        var order = new Order(orderArgs, orderService);
        await order.CompletionTask;
        return order;
    }

    public async Task Placed(OrderArgs orderArgs, IOrderService service)
    {
        //todo! add guards here
        ApplyAndPublish(new OrderPlaced(orderArgs.OrderNumber, orderArgs.Title));
    }

    public async Task UpdatedInfo(OrderArgs orderArgs, IOrderService service)
    {
        //todo! add guards here
        ApplyAndPublish(new OrderInfoUpdated(orderArgs.Title));
    }

    public async Task Remove(IOrderService service)
    {
        //todo! add guards here
        ApplyAndPublish(new OrderRemoved(Id));
    }
}