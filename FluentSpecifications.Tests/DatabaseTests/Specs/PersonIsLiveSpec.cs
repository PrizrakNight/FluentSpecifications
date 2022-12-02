using FluentSpecifications.Tests.Database.Entities;
using System.Linq.Expressions;

namespace FluentSpecifications.Tests.DatabaseTests.Specs
{
    internal class PersonIsLiveSpec : ISpecification<Person>
    {
        public Expression<Func<Person, bool>> Condition => x => x.IsLive == true;
    }
}
