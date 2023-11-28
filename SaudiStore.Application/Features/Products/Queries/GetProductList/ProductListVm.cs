using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
