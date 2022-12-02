using FluentSpecifications.Tests.InMemoryTests.Specs;

namespace FluentSpecifications.Tests.InMemoryTests
{
    [TestClass]
    public class MultipleSpecTests
    {
        [TestMethod]
        public void GreaterAndLess_ToArray_ShouldReturnTwoItems()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder()
                .UseSpecification<GreaterThanSpec>(x => x.Value = 2)
                .And<LessThanSpec>(s => s.Value = 5)
                .ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(4, result[1]);
        }
    }
}
