using SaudiStore.Domain.Common;

namespace SaudiStore.Domain.Entities
{
    public class Product: AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;

    }
}
