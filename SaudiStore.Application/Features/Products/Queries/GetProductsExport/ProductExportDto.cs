namespace SaudiStore.Application.Features.Products.Queries.GetProductsExport
{
    public class ProductExportDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
