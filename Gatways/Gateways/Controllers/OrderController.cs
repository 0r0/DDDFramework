using DDDFramework.Application.Order;
using DDDFramework.Core.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api")]
public class OrderController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    [HttpPost("")]
    public IActionResult Post(CreateOrderCommand command)
    {
        return Created("", command.Id);
    }
}