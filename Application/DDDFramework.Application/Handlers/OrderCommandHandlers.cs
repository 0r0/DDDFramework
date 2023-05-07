using DDDFramework.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Application.Handlers;

public class OrderCommandHandlers :ICommandHandler<OrderCreated>,
    ICommandHandler<OrderActivated>,
    ICommandHandler<OrderPlaced>,
    ICommandHandler<OrderInfoUpdated>
{
    public Task Handle(OrderCreated command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(OrderActivated command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(OrderPlaced command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(OrderInfoUpdated command)
    {
        throw new NotImplementedException();
    }
}