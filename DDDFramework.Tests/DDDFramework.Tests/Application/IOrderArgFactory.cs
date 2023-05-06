using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Domain.Order;

namespace DDDFramework.Tests.Application;

public interface IOrderArgFactory
{

    OrderArgs CreateFrom(CreateOrderCommand command);
    OrderArgs CreateFrom(PlaceOrderCommand command);
    OrderArgs CreateFrom(UpdateOrderInfoCommand command);
    
}