using DDDFramework.Core.Application.Contracts;
using DDDFramework.Query.Contracts;
using DDDFramework.Query.Requests;
using DDDFramework.Query.Responses;
using MongoDB.Driver;

namespace DDDFramework.Query.Handlers;

public class OrderQueryHandlers : IQueryHandler<GetAllOrders, IReadOnlyCollection<OrderResponse>>
{
    private readonly IMongoCollection<OrderDto> _mongoCollection;

    public OrderQueryHandlers(IMongoCollection<OrderDto> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task<IReadOnlyCollection<OrderResponse>> Handle(GetAllOrders query)
    {
        //todo! change in future we write the code only for sampling w
        var orderDtos = await _mongoCollection.FindAsync(a => a.Id != null);
        return orderDtos.ToList().Select(a => new OrderResponse()
        ).ToList();
    }
}