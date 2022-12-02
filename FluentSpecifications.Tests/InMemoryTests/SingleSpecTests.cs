using FluentSpecifications.Tests.InMemoryTests.Specs;

namespace FluentSpecifications.Tests.InMemoryTests
{
    [TestClass]
    public class SingleSpecTests
    {
        [TestMethod]
        public void Between_ToArray_ShouldReturnTwoItems()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder(x => x.UseSpecification<BetweenSpec>(s =>
                {
                    s.Min = 2;
                    s.Max = 3;
                }))
                .ToArray();

            Assert.AreEqual(2, result[0]);
            Assert.AreEqual(3, result[1]);
        }

        [TestMethod]
        public void Between_FirstOrDefault_ShouldReturnFirst()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder(x => x.UseSpecification<BetweenSpec>(s =>
                {
                    s.Min = 2;
                    s.Max = 4;
                }))
                .FirstOrDefault();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Between_FirstOrDefault_ShouldReturnDefault()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder(x => x.UseSpecification<BetweenSpec>(s =>
                {
                    s.Min = 6;
                    s.Max = 10;
                }))
                .FirstOrDefault();

            Assert.AreEqual(default, result);
        }

        [TestMethod]
        public void Between_First_ShouldReturnFirst()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder(x => x.UseSpecification<BetweenSpec>(s =>
                {
                    s.Min = 2;
                    s.Max = 4;
                }))
                .First();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Between_First_ShouldThrowException()
        {
            var values = new[] { 1, 2, 3, 4, 5 };

            var result = values
                .AsSpecBuilder(x => x.UseSpecification<BetweenSpec>(s =>
                {
                    s.Min = 6;
                    s.Max = 10;
                }))
                .First();
        }
    }
}
