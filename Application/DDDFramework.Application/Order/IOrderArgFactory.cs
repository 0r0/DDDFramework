using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Order;

public interface IOrderArgFactory
{
    Task<OrderArgs> CreateFrom(OrderCreatedCommand orderCreatedCommand);

    Task<OrderArgs> CreateFrom(OrderPlacedCommand orderPlacedCommand);
    Task<OrderArgs> CreateFrom(OrderActivatedCommand orderActivatedCommand);
    
}