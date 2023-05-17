namespace Gateways.Controllers;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public long OrderNumber { get; set; }
    public bool IsActive { get; set; }
}