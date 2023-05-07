using DDDFramework.Application.Contracts;
using DDDFramework.Application.Order;
using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Handlers;

public class OrderCommandHandlers : ICommandHandler<CreateOrderCommand>,
    ICommandHandler<ActivateOrderCommand>,
    ICommandHandler<PlaceOrderCommand>,
    ICommandHandler<UpdateOrderInfoCommand>
{
    private readonly IOrderRepository _repository;
    private readonly IOrderArgFactory _argFactory;

    public OrderCommandHandlers(IOrderRepository repository, IOrderArgFactory argFactory)
    {
        _repository = repository;
        _argFactory = argFactory;
    }


    public Task Handle(CreateOrderCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        // var order = new Domain.Order.Order
        // _repository.Add();
        return Task.CompletedTask;
    }

    public Task Handle(ActivateOrderCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(PlaceOrderCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(UpdateOrderInfoCommand command)
    {
        throw new NotImplementedException();
    }
}