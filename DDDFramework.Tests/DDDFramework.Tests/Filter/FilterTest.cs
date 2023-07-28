using DDDFramework.Core.Filter;
using DDDFramework.Tests.BuilderFactory;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public class FilterTest
{
    [Fact]
    public void check_filter_is_worked()
    {
        var condition = new GreaterThanCondition("greaterThan", 40);
        var operation = new GreaterThanOperation("greaterThan");
        var filter = new Core.Filter.Filter(condition, operation);
        const string jsonString = @"{'greaterThan':100}";
        var expected = JObject.Parse(jsonString);

        var actual = filter.Apply(expected);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void when_absent_adding_another_value_operation()
    {
        var jsonString = @"{'id':'01','fullName':'Mehdi Goharinezhad'}";
        var expected = @"{'id':'01','name':'Mehdi Goharinezhad'}";
        var absentCondition = new AbsentCondition("name");
        var anotherValueOperation = new AnotherPropertyOperation("name", "fullName");
        var filter = new Core.Filter.Filter(absentCondition, anotherValueOperation);
        var actual = filter.Apply(JObject.Parse(jsonString));
        actual.Should().BeEquivalentTo(JObject.Parse(expected));
    }

    [Fact]
    public void check_filter_factory_work_properly()
    {
        const string jsonString = @"{'fullName':'Mehdi Goharinezhad'}";
        var jsonJObject = JObject.Parse(jsonString);
        var expectedString = @"{'name':'Mehdi Goharinezhad','description':'default description'}";
        var expectedJson = JObject.Parse(expectedString);
        var filterFactory = new FilterBuilder();
        var firstFilter = filterFactory.WhenAbsent("name").AnotherProperty("name", "fullName")
            .WhenAbsent("description")
            .DefaultValue("description", "default description").Build();
        var actual = firstFilter.Apply(jsonJObject);
        actual.Should().BeEquivalentTo(expectedJson);
    }
}