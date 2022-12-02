namespace FluentSpecifications.Tests.Database.Entities
{
    public class PersonItem
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public virtual Person? Person { get; set; }
    }
}
