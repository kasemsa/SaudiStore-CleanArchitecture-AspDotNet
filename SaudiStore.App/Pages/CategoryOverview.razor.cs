using SaudiStore.App.Contracts;
using SaudiStore.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudiStore.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryProductsViewModel> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesWithProducts(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeProductArgs args)
        {
            if((bool)args.Value)
            {
                Categories = await CategoryDataService.GetAllCategoriesWithProducts(true);
            }
            else
            {
                Categories = await CategoryDataService.GetAllCategoriesWithProducts(false);
            }
        }
    }
}
