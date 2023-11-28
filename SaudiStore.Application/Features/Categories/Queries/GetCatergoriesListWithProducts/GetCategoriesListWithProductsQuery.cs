using MediatR;
using SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts;

namespace SaudiStore.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
    public class GetCategoriesListWithProductsQuery: IRequest<List<CategoryProductListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
