using FluentSpecifications.Tests.Database;
using FluentSpecifications.Tests.Database.Entities;
using FluentSpecifications.Tests.DatabaseTests.Specs;

namespace FluentSpecifications.Tests.DatabaseTests
{
    [TestClass]
    public class MultipleSpecTests : DatabaseTestsBase
    {
        [TestMethod]
        public void AgeGreaterThan20_First_ShouldReturnPePe()
        {
            var builder = seed.DbContext.Persons
                .AsSpecBuilder()
                .UseExpressionBrowser<ExpressionToSqlBrowser<Person>>()
                .UseSpecification<PersonAgeGreaterThanSpec>(x => x.Age = 20);

            var result = builder.First();

            Assert.AreEqual("Pe-pe", result.Name);
            Assert.AreEqual(23, result.Age);
        }

        [TestMethod]
        public void AgeGreaterThan18AndIsLive_First_ShouldReturnPePe()
        {
            var builder = seed.DbContext.Persons
                .AsSpecBuilder()
                .UseExpressionBrowser<ExpressionToSqlBrowser<Person>>()
                .UseSpecification<PersonAgeGreaterThanSpec>(x => x.Age = 18)
                .And<PersonIsLiveSpec>();

            var result = builder.First();

            Assert.AreEqual("Pe-pe", result.Name);
            Assert.AreEqual(23, result.Age);
        }

        [TestMethod]
        public void IsLiveOrDead_ToArray_ShouldReturnAllPersons()
        {
            var builder = seed.DbContext.Persons
                .AsSpecBuilder()
                .UseExpressionBrowser<ExpressionToSqlBrowser<Person>>()
                .UseSpecification<PersonIsLiveSpec>()
                .Or<PersonIsDeadSpec>();

            var result = builder.ToArray();

            Assert.AreEqual(seed.CurrentPersons.Length, result.Length);
        }

        [TestMethod]
        public void IsLiveOrDeadAndAgeLessThan23_ToArray_ShouldReturnPersons()
        {
            var builder = seed.DbContext.Persons
                .AsSpecBuilder()
                .UseExpressionBrowser<ExpressionToSqlBrowser<Person>>()
                .UseSpecification<PersonIsLiveSpec>()
                .Or<PersonIsDeadSpec>()
                .And<PersonAgeLessThanSpec>(x => x.Age = 23);

            var result = builder.ToArray();

            var minAge = result.Select(x => x.Age).Min();
            var maxAge = result.Select(x => x.Age).Max();

            Assert.AreEqual(12, minAge);
            Assert.AreEqual(20, maxAge);
        }

        [TestMethod]
        public void AgeBetween18And22AndIsDead_First_ShouldReturnJohn()
        {
            var builder = seed.DbContext.Persons
                .AsSpecBuilder()
                .UseExpressionBrowser<ExpressionToSqlBrowser<Person>>()
                .UseSpecification<PersonAgeGreaterThanSpec>(x => x.Age = 18)
                .And<PersonAgeLessThanSpec>(x => x.Age = 22)
                .And<PersonIsDeadSpec>();

            var result = builder.First();

            Assert.AreEqual("John", result.Name);
            Assert.AreEqual(20, result.Age);
        }
    }
}
