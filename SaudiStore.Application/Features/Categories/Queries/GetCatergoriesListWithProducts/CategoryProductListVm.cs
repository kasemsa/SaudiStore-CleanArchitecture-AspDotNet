using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts
{
    public class CategoryProductListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } 
        public ICollection<CategoryProductDto>? Products { get; set; }
    }
}
