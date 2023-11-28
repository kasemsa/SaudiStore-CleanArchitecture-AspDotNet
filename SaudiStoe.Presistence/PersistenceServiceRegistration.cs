using SaudiStore.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaudiStoe.Presistence;
using SaudiStoe.Persistence.Repositories;
using SaudiStore.Persistence.Repositories;
using SaudiStore.Application.Contracts.Infrastructure;

namespace SaudiStoe.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SaudiStoreDbContext>(options =>
                options.UseSqlServer(connectionString: configuration.GetConnectionString("SaudiStoreConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            

            return services;    
        }
    }
}
