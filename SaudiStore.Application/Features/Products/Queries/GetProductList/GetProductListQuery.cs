using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductListVm>>
    {
    }
}
