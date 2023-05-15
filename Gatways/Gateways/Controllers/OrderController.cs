using DDDFramework.Application.Order;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api")]
public class OrderController : ControllerBase
{
    [HttpPost("")]
    public IActionResult Post(CreateOrderCommand command)
    {
        return Created("", command.Id);
    }
}