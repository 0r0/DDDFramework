using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.EventStore;
using DDDFramework.Domain.Order;

namespace Persistence.ES;

public class OrderRepository : IOrderRepository
{
    private readonly IEventSourceRepository<Order, OrderId> _repository;

    public OrderRepository(IEventSourceRepository<Order, OrderId> repository)
    {
        _repository = repository;
    }

    public Order Get(OrderId orderId)
    {
        return  _repository.GetById(orderId);
    }

    public void Add(Order order)
    {
         _repository.AppendEvents(order);
    }

    public void Update(Order order)
    {
         _repository.AppendEvents(order);
    }
}