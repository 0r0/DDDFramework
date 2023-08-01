using DDDFramework.Domain.Contracts.Order;
using FizzWare.NBuilder;

namespace DDDFramework.Domain.Order;

public class OrderArgs
{
    private OrderArgs()
    {
    }

    public OrderId Id { get; set; }
    public string? Title { get; set; }
    public long OrderNumber { get; set; }
    public bool IsActive { get; set; }

    public static ISingleObjectBuilder<OrderArgs> Builder
        => new Builder().CreateNew<OrderArgs>();


}