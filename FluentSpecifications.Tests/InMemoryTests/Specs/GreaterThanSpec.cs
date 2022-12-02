using System.Linq.Expressions;

namespace FluentSpecifications.Tests.InMemoryTests.Specs
{
    internal class GreaterThanSpec : ISpecification<int>
    {
        public Expression<Func<int, bool>> Condition => x => x > Value;

        public int Value { get; set; }
    }
}
