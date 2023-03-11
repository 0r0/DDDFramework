using System.Runtime.InteropServices;
using Aggregate;
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
}