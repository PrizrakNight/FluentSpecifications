using FluentSpecifications.Tests.Database.Entities;

namespace FluentSpecifications.Tests.Database.Seeds
{
    public class BasePersonsSeed
    {
        public EfCoreContext DbContext
        {
            get
            {
                return AssemblyInitializer.DbContext;
            }
        }

        public Person[] CurrentPersons { get; private set; } = null!;

        public void SeedData()
        {
            CurrentPersons = GetPersons();

            AssemblyInitializer.DbContext.Persons.AddRange(CurrentPersons);
            AssemblyInitializer.DbContext.SaveChanges();
        }

        public void CleanupData()
        {
            AssemblyInitializer.DbContext.Persons.RemoveRange(CurrentPersons);
            AssemblyInitializer.DbContext.SaveChanges();
        }

        protected virtual Person[] GetPersons()
        {
            return new[]
            {
                new Person
                {
                    Age = 12,
                    Name = "Steve",
                    IsLive = false,
                    Items = new List<PersonItem>
                    {
                        new PersonItem
                        {
                            Name = "Stone Axe",
                        }
                    }
                },
                new Person
                {
                    Age = 18,
                    Name = "Marcus",
                    IsLive = true,
                    Items = new List<PersonItem>
                    {
                        new PersonItem
                        {
                            Name = "Stone Sword",
                        }
                    }
                },
                new Person
                {
                    Age = 23,
                    Name = "Pe-pe",
                    IsLive = true
                },
                new Person
                {
                    Age = 20,
                    Name = "John",
                    IsLive = false
                }
            };
        }
    }
}
