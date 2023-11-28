using SaudiStore.Domain.Common;

namespace SaudiStore.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}
