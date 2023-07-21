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
      var filter = new Filter(condition,operation);
      const string jsonString = @"{'greaterThan':100}";
      var expected = JObject.Parse(jsonString);

      var actual = filter.Apply(expected);
      actual.Should().BeEquivalentTo(expected);
   }
}