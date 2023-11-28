using AutoMapper;
using Blazored.LocalStorage;
using SaudiStore.App.Contracts;
using SaudiStore.App.Services.Base;
using SaudiStore.App.ViewModels;
using SaudiStore.App.Services.Base;
using SaudiStore.Application.Features.Products.Commands.CreateProduct;

namespace SaudiStore.App.Services
{
    public class ProductDataService: BaseDataService, IProductDataService
    {
        
        private readonly IMapper _mapper;

        public ProductDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductListViewModel>> GetAllProducts()
        {
            var allProducts = await _client.GetAllProductsAsync();
            var mappedProducts = _mapper.Map<ICollection<ProductListViewModel>>(allProducts);
            return mappedProducts.ToList();
        }

        public async Task<ProductDetailViewModel> GetProductById(Guid id)
        {
            var selectedProduct = await _client.GetProductByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductDetailViewModel>(selectedProduct);
            return mappedProduct;
        }

        public async Task<ApiResponse<Guid>> CreateProduct(ProductDetailViewModel ProductDetailViewModel)
        {
            try
            {
                CreateProductCommand createProductCommand = _mapper.Map<CreateProductCommand>(ProductDetailViewModel);
                var newId = await _client.AddProductAsync(createProductCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateProduct(ProductDetailViewModel ProductDetailViewModel)
        {
            try
            {
                UpdateProductCommand updateProductCommand = _mapper.Map<UpdateProductCommand>(ProductDetailViewModel);
                await _client.UpdateProductAsync(updateProductCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteProduct(Guid id)
        {
            try
            {
                await _client.DeleteProductAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
