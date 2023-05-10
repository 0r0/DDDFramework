using DDDFramework.Application.Contracts;
using DDDFramework.Application.Order;
using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Handlers;

public class OrderCommandHandlers : ICommandHandler<CreateOrderCommand>,
    ICommandHandler<PlaceOrderCommand>,
    ICommandHandler<UpdateOrderInfoCommand>
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
        await _repository.Add(order).ConfigureAwait(false);
    }


    public async Task Handle(PlaceOrderCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        var order = await _repository.Get(arg.Id);
        await order.Placed(arg, _service);
        await _repository.Add(order).ConfigureAwait(false);
    }

    public async Task Handle(UpdateOrderInfoCommand command)
    {
        var arg = _argFactory.CreateFrom(command);
        var order = await _repository.Get(arg.Id);
        await order.UpdatedInfo(arg, _service);
    }
}