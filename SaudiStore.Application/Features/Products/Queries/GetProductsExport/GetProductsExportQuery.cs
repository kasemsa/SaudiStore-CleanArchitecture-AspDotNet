using MediatR;

namespace SaudiStore.Application.Features.Products.Queries.GetProductsExport
{
    public class GetProductsExportQuery: IRequest<ProductExportFileVm>
    {
    }
}
