using AutoMapper;
using MediatR;
using OpenQA.Selenium;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;

namespace SaudiStore.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var @product = await _productRepository.GetByIdAsync(request.Id);
            var productDetailDto = _mapper.Map<ProductDetailVm>(@product);

            var category = await _categoryRepository.GetByIdAsync(@product.CategoryId);

            if (category == null)
            {
                throw new NotFoundException(nameof(Product));
            }
            productDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return productDetailDto;
        }


    }
}
