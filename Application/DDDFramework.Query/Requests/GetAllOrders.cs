using DDDFramework.Core.Application.Contracts;
using DDDFramework.Query.Responses;

namespace DDDFramework.Query.Requests;

public class GetAllOrders : IQuery<IReadOnlyCollection<OrderResponse>>
{
}