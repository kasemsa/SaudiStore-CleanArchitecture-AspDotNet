using System;

namespace SaudiStore.App.ViewModels
{
    public class ProductNestedViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? CompanyName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
