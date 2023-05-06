namespace DDDFramework.Application.Contracts.Orders;

public class CreateOrderCommand
{
    public Guid Id { get; set; }
    public long OrderNumber { get; set; }

    public string Title { get; set; }

    public bool IsActive { get; set; }
}