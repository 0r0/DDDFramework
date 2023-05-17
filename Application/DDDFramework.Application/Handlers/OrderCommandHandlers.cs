using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Application.Order;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Handlers;

public class OrderCommandHandlers : ICommandHandler<CreateOrderCommand>,
    ICommandHandler<PlaceOrderCommand>,
    ICommandHandler<UpdateOrderInfoCommand>,
    ICommandHandler<RemoveOrderCommand>
{
    private readonly IOrderRepository _repository;
    private readonly IOrderArgFactory _argFactory;
    private readonly IOrderService _service;

    public OrderCommandHandlers(IOrderRepository repository, IOrderArgFactory argFactory, IOrderService service)
    {
        _repository = repository;
        _argFactory = argFactory;
        _service = service;
    }


    public async Task Handle(CreateOrderCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        var order = await Domain.Order.Order.Create(arg, _service);
        _repository.Add(order);
    }


    public async Task Handle(PlaceOrderCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        var order = _repository.Get(arg.Id);
        await order.Placed(arg, _service);
        _repository.Add(order);
    }

    public async Task Handle(UpdateOrderInfoCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        var order = _repository.Get(arg.Id);
        await order.UpdatedInfo(arg, _service);
    }

    public async Task Handle(RemoveOrderCommand command)
    {
        var order = _repository.Get(new OrderId(command.Id));
        await order.Remove(_service);
    }
}