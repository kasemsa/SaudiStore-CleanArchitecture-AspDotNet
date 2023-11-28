using AutoMapper;
using SaudiStore.Application.Contracts.Infrastructure;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;
using MediatR;

namespace SaudiStore.Application.Features.Products.Queries.GetProductsExport
{
    public class GetProductsExportQueryHandler : IRequestHandler<GetProductsExportQuery, ProductExportFileVm>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetProductsExportQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _csvExporter = csvExporter;
        }

        public async Task<ProductExportFileVm> Handle(GetProductsExportQuery request, CancellationToken cancellationToken)
        {
            var allProducts = _mapper.Map<List<ProductExportDto>>((await _productRepository.ListAllAsync()));

            var fileData = _csvExporter.ExportProductsToCsv(allProducts);

            var ProductExportFileDto = new ProductExportFileVm() { ContentType = "text/csv", Data = fileData, ProductExportFileName = $"{Guid.NewGuid()}.csv" };

            return ProductExportFileDto;
        }
    }
}
