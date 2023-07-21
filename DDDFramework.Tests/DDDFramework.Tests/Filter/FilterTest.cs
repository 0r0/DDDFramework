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
      var filter = new Core.Filter.Filter(condition,operation);
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
      var anotherValueOperation = new AnotherPropertyOperation("name","fullName");
      var filter = new Core.Filter.Filter(absentCondition, anotherValueOperation);
      var actual = filter.Apply(JObject.Parse(jsonString));
      actual.Should().BeEquivalentTo(JObject.Parse(expected));
   }
}