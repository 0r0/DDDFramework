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
        return NoContent();
    }

    [HttpPut("activate/{id:guid}")]
    public async Task<IActionResult> Put(Guid id, ActivateOrderCommand command)
    {
        return NoContent();
    }
}