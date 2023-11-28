namespace SaudiStore.App.ViewModels
{
    public class CategoryProductsViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductNestedViewModel>? Products { get; set; }
    }
}
