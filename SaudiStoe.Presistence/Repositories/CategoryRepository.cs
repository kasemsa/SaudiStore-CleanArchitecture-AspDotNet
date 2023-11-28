using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SaudiStoe.Persistence.Repositories;
using SaudiStoe.Presistence;

namespace SaudiStore.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SaudiStoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithProduct(bool includePassedProducts)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Products).ToListAsync();
            if(!includePassedProducts)
            {
                allCategories.ForEach(p => p.Products!.ToList());
            }
            return allCategories;
        }
    }
}
