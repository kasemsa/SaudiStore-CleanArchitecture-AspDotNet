using SaudiStore.Application.Features.Products.Queries.GetProductsExport;
using System.Collections.Generic;

namespace SaudiStore.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportProductsToCsv(List<ProductExportDto> eventExportDtos);
    }
}
