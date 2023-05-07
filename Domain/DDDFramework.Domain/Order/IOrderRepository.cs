using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public interface IOrderRepository : IRepository
{
    Order Get(OrderId orderId);
    void Add(Order order);
}