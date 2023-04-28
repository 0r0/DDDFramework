namespace DDDFramework.Tests;

public class OrderArgs
{
    public OrderArgs()
    {
    }

    public OrderId Id { get; set; }
    public string Title { get; set; }
    public long OrderNumber { get; set; }
    
    //todo! make a builder here
}