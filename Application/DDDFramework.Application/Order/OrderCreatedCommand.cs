namespace DDDFramework.Application.Order;

public class OrderCreatedCommand
{
    public Guid Id { get; set; }
    public long OrderNumber { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
}