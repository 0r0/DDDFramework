using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;

namespace DDDFramework.Tests;

public class ArgBuilderTest
{
    [Fact]
    private void set_value_of_argument_that_created_by_single_object_builder()
    {
        var singleObject = new SingleObjectBuilder<OrderArgs,Guid>();
        // singleObject.With(a=>a.Id.DbId=Guid.NewGuid(),Guid.NewGuid());

    }
}