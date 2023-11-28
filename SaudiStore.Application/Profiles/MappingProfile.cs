using AutoMapper;
using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudiStore.Application.Features.Products.Queries.GetProductDetail;
using SaudiStore.Application.Features.Products.Queries.GetProductList;
using SaudiStore.Application.Features.Categories.Queries.GetCategoriesList;
using SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts;
using SaudiStore.Application.Features.Products.Commands.CreateProduct;
using SaudiStore.Application.Features.Products.Commands.DeleteProduct;

namespace SaudiStore.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,ProductListVm>().ReverseMap();
            CreateMap<Product,ProductDetailVm>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryProductListVm>();
         
        }
    }
}
