using FluentSpecifications.Tests.Database.Seeds;

namespace FluentSpecifications.Tests.Database
{
    public class DatabaseTestsBase
    {
        protected readonly BasePersonsSeed seed = new();

        [TestInitialize]
        public void TestInitialize()
        {
            seed.SeedData();

            OnTestInitialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            seed.CleanupData();

            OnTestCleanup();
        }

        protected virtual void OnTestInitialize() { }
        protected virtual void OnTestCleanup() { }
    }
}
