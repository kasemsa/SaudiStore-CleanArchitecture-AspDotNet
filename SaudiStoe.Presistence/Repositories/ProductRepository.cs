using SaudiStoe.Persistence.Repositories;
using SaudiStoe.Presistence;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;

namespace SaudiStore.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SaudiStoreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsProductNameAndCompanyNameUniqe(string name, string? companyName)
        {
            var matches = _dbContext.Products.Any(e => e.Name.Equals(name) && e.CompanyName.Equals(companyName));
            return Task.FromResult(matches);
        }
    }
}
