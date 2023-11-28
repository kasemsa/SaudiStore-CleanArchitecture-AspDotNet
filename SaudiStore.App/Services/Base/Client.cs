using SaudiStore.App.Services;
using System.Net.Http;

namespace SaudiStoreApp.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return HttpClient;
            }
        }

        public Task<CreateCategoryCommandResponse> AddCategoryAsync(CreateCategoryCommand body)
        {
            throw new NotImplementedException();
        }

        public Task<CreateCategoryCommandResponse> AddCategoryAsync(CreateCategoryCommand body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> AddProductAsync(CreateProductCommand body)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> AddProductAsync(CreateProductCommand body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<FileResponse> ExportProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FileResponse> ExportProductsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryListVm>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryListVm>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductListVm>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductListVm>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryProductListVm>> GetCategoriesWithProductsAsync(bool? includeHistory)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryProductListVm>> GetCategoriesWithProductsAsync(bool? includeHistory, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PagedOrdersForMonthVm> GetPagedOrdersForMonthAsync(DateTime? date, int? page, int? size)
        {
            throw new NotImplementedException();
        }

        public Task<PagedOrdersForMonthVm> GetPagedOrdersForMonthAsync(DateTime? date, int? page, int? size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailVm> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailVm> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest body)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductCommand body)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductCommand body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
