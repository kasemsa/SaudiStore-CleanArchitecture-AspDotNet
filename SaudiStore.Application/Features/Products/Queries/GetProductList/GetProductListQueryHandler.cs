using AutoMapper;
using MediatR;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery,
        List<ProductListVm>>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;

        }

        public async Task<List<ProductListVm>> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ProductListVm>>(allProducts);
        }
    }
}
