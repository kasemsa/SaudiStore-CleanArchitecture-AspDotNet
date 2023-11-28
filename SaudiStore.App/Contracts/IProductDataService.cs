using SaudiStore.App.Services.Base;
using SaudiStore.App.ViewModels;

namespace SaudiStore.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductListViewModel>> GetAllProducts();
        Task<ProductDetailViewModel> GetProductById(Guid id);
        Task<ApiResponse<Guid>> CreateProduct(ProductDetailViewModel ProductDetailViewModel);
        Task<ApiResponse<Guid>> UpdateProduct(ProductDetailViewModel ProductDetailViewModel);
        Task<ApiResponse<Guid>> DeleteProduct(Guid id);
    }
}
