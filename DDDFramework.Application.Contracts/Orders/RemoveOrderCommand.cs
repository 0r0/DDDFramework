namespace DDDFramework.Application.Contracts.Orders;

public class RemoveOrderCommand
{
    public Guid Id { get; set; }
    public long Version { get; set; }
}