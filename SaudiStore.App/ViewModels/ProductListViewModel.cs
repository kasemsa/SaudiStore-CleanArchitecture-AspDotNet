namespace SaudiStore.App.ViewModels
{
    public class ProductListViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
