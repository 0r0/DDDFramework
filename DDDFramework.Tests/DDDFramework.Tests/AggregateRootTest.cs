using Aggregate;

namespace DDDFramework.Tests;

public class AggregateRootTest
{
    [Fact]
    public void Aggregate_root_Id_should_be_getted_and_setted()
    {
        var a = new AggregateRoot<Guid>();
        var guid = Guid.NewGuid();
        // a.Id=new Id<Guid>(guid);
        //
        // a.Id.DbId.Should().Be(guid);
    }
}