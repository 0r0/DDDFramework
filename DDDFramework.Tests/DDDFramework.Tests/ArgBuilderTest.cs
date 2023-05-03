using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;
using FizzWare.NBuilder;

namespace DDDFramework.Tests;

public class ArgBuilderTest
{
    [Theory]
    [InlineData("Ali",false,12)]
    private void set_value_of_argument_that_created_by_single_object_builder(string title,bool isActive,long orderNumber)
    {
        var orderArg = OrderArgs.Builder
            .With(a => a.Id, new OrderId(Guid.NewGuid()))
            .With(a => a.Title, title)
            .With(a => a.IsActive, isActive)
            .With(a => a.OrderNumber, orderNumber)
            .Build();
        Assert.Equal(title,orderArg.Title);
        Assert.Equal(isActive,orderArg.IsActive);
        Assert.Equal(orderNumber,orderArg.OrderNumber);

    }
}