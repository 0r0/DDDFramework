using Aggregate;
using DDDFramework.Domain.Order;
using FluentAssertions;

namespace DDDFramework.Tests;

public class IdTest
{
    [Fact]
    private void Id_must_set_value_from_constructor()

    {
        var guid = Guid.NewGuid();
        var id = new Id<Guid>(guid);
        id.DbId.Should().Be(guid);
    }

    [Fact]
    private void Id_can_be_set_For_aggregateRoot()
    {
        var orderAggregate = new Order();
        orderAggregate.Id = new OrderId(Guid.Empty);
        Assert.Equal(Guid.Empty, orderAggregate.Id.DbId);
    }
}