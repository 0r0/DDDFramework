using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Order;

public interface IOrderArgFactory
{

    OrderArgs CreateFrom(CreateOrderCommand command);
    OrderArgs CreateFrom(PlaceOrderCommand command);
    OrderArgs CreateFrom(UpdateOrderInfoCommand command);
    
}