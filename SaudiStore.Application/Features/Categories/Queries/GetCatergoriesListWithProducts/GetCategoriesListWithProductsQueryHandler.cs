﻿using AutoMapper;
using SaudiStore.Application.Contracts.Persistence;
using MediatR;
using SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts;

namespace SaudiStore.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
    public class GetCategoriesListWithProductsQueryHandler : IRequestHandler<GetCategoriesListWithProductsQuery, List<CategoryProductListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithProductsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryProductListVm>> Handle(GetCategoriesListWithProductsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithProduct(request.IncludeHistory);
            return _mapper.Map<List<CategoryProductListVm>>(list);
        }
    }
}
