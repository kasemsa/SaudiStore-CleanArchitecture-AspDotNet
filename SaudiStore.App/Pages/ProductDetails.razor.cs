
using SaudiStore.App.Services.Base;
using SaudiStore.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SaudiStore.App.Contracts;

namespace SaudiStore.App.Pages
{
    public partial class ProductDetails
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ObservableCollection<CategoryViewModel> Categories { get; set; } 
            = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string ProductId { get; set; }
        private Guid SelectedProductId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(ProductId, out SelectedProductId))
            {
                ProductDetailViewModel = await ProductDataService.GetProductById(SelectedProductId);
                SelectedCategoryId = ProductDetailViewModel.CategoryId.ToString();
            }

            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            ProductDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedProductId == Guid.Empty)
            {
                response = await ProductDataService.CreateProduct(ProductDetailViewModel);
            }
            else
            {
                 response = await ProductDataService.UpdateProduct(ProductDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeleteProduct()
        {
            var response = await ProductDataService.DeleteProduct(SelectedProductId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Productoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/Productoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
