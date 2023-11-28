using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts
{
    public class CategoryProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? CompanyName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
