using DDDFramework.Core.Application.Contracts;
using DDDFramework.Query.Requests;
using DDDFramework.Query.Responses;

namespace DDDFramework.Query.Handlers;

public class OrderQueryHandlers : IQueryHandler<GetAllOrders, IReadOnlyCollection<OrderResponse>>
{
    public async Task<IReadOnlyCollection<OrderResponse>> Handle(GetAllOrders query)
    {
        throw new NotImplementedException();
    }
}