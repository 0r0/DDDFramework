namespace DDDFramework.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
    }
}

public class IdTest
{
    [Fact]
    private void Id_must_set_value_from_constructor()
    {
        var id = new Id<Guid>();
    }
}