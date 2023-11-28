using SaudiStore.App.Contracts;
using SaudiStore.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaudiStore.App.Pages
{
    public partial class ProductOverview
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ProductListViewModel> Products { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = await ProductDataService.GetAllProducts();
        }

        protected void AddNewProduct()
        {
            NavigationManager.NavigateTo("/Productdetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportProducts()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:7020/api/Products/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }
    }
}
