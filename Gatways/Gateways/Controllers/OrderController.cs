using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Core.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    public OrderController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    [HttpPost]
    public IActionResult Post(CreateOrderCommand command)
    {
        _commandBus.Dispatch(command);
        return Created("", command.Id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, PlaceOrderCommand command)
    {
        command.Id = id;
        _commandBus.Dispatch(command);
        return NoContent();
    }

    [HttpPut("activate/{id:guid}")]
    public async Task<IActionResult> Put(Guid id, ActivateOrderCommand command)
    {
        _commandBus.Dispatch(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}/{version:long}")]
    public async Task<IActionResult> Delete(Guid id, long version)
    {
        _commandBus.Dispatch(new RemoveOrderCommand
        {
            Id = id,
            Version =version
        });
        return NoContent();
    }
}