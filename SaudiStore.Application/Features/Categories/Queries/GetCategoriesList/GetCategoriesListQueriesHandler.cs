using AutoMapper;
using MediatR;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Categories.Queries.GetCategoriesList
{
    internal class GetCategoriesListQueriesHandler : IRequestHandler<GetCategoriesListQueries, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueriesHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        { 
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQueries request, CancellationToken cancellationToken)
        {
            var allCategory = (await _categoryRepository.ListAllAsync());
            return _mapper.Map<List<CategoryListVm>>(allCategory);
        }
    }
}
