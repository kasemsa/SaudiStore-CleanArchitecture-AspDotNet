using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Contracts.Persistence
{
    public interface ICategoryRepository:IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProduct(bool includePassedProduct);
    }
}
