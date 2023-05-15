using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderQueryController : ControllerBase
{

    [HttpGet]
    public async Task<IReadOnlyCollection<OrderResponse>> Get()
    {
        return new List<OrderResponse>();
    }
}