using System.Linq.Expressions;

namespace FluentSpecifications.Tests.InMemoryTests.Specs
{
    internal class BetweenSpec : ISpecification<int>
    {
        public Expression<Func<int, bool>> Condition
        {
            get
            {
                return val => val >= Min && val <= Max;
            }
        }

        public int Min { get; set; }
        public int Max { get; set; }
    }
}
