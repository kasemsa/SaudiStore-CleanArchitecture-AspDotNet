using AutoMapper;
using SaudiStore.App.Services;
using SaudiStore.App.ViewModels;

namespace SaudiStore.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<ProductListVm, ProductListViewModel>().ReverseMap();
            CreateMap<ProductDetailVm, ProductDetailViewModel>().ReverseMap();

            CreateMap<ProductDetailViewModel, CreateProductCommand>().ReverseMap();
            CreateMap<ProductDetailViewModel, UpdateProductCommand>().ReverseMap();

            CreateMap<CategoryProductDto, ProductNestedViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryProductListVm, CategoryProductsViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryDto>().ReverseMap();

            CreateMap<PagedOrdersForMonthVm, PagedOrderForMonthViewModel>().ReverseMap();
            CreateMap<OrdersForMonthDto, OrdersForMonthListViewModel>().ReverseMap();
        }
    }
}
