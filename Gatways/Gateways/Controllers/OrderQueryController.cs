using DDDFramework.Core.Application.Contracts;
using DDDFramework.Query.Requests;
using DDDFramework.Query.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderQueryController : ControllerBase
{
    private readonly IQueryBus _queryBus;

    public OrderQueryController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<OrderResponse>> Get()
    {
        return await _queryBus.Execute<GetAllOrders, 
            IReadOnlyCollection<OrderResponse>>(new GetAllOrders());
      
    }
}