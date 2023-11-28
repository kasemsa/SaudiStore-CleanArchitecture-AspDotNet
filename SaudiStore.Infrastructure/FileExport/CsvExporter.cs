using CsvHelper;
using SaudiStore.Application.Contracts.Infrastructure;
using SaudiStore.Application.Features.Products.Queries.GetProductsExport;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportProductsToCsv(List<ProductExportDto> ProductExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(ProductExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
