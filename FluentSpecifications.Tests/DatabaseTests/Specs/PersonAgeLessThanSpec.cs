using FluentSpecifications.Tests.Database.Entities;
using System.Linq.Expressions;

namespace FluentSpecifications.Tests.DatabaseTests.Specs
{
    internal class PersonAgeLessThanSpec : ISpecification<Person>
    {
        public int Age { get; set; }

        public Expression<Func<Person, bool>> Condition => x => x.Age < Age;
    }
}
