using MediatR;

namespace SaudiStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
