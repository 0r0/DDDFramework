using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public interface IOrderRepository : IRepository
{
    Task<Order> Get(OrderId orderId);
    Task Add(Order order);
}