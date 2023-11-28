using SaudiStore.App.Services;
using SaudiStore.App.Services.Base;
using SaudiStore.App.ViewModels;

namespace SaudiStore.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryProductsViewModel>> GetAllCategoriesWithProducts(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
