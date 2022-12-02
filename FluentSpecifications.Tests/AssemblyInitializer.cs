using FluentSpecifications.Tests.Database;
using Microsoft.EntityFrameworkCore;

namespace FluentSpecifications.Tests
{
    [TestClass]
    public class AssemblyInitializer
    {
        public static EfCoreContext DbContext { get; private set; } = null!;

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            var options = new DbContextOptionsBuilder<EfCoreContext>();

            options.UseSqlite(@"Data Source=.\Test.db;");

            DbContext = new EfCoreContext(options.Options);
            DbContext.Database.EnsureCreated();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
}
