using FluentSpecifications.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluentSpecifications.Tests.Database
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<PersonItem> PersonItems { get; set; } = null!;

        public EfCoreContext(DbContextOptions options) : base(options)
        {
        }
    }
}
