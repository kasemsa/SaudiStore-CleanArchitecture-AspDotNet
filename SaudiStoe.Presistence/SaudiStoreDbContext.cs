using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaudiStore.Domain.Common;
using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStoe.Presistence
{
    public class SaudiStoreDbContext:DbContext
    {
        public SaudiStoreDbContext(DbContextOptions<SaudiStoreDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaudiStoreDbContext).Assembly);

            //seed data, added through migrations
            var batteriesGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var invertersGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var solarPanelsGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var accessoriesGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = batteriesGuid,
                Name = "Batteries"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = invertersGuid,
                Name = "Inverters"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = solarPanelsGuid,
                Name = "Solar Panel"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = accessoriesGuid,
                Name = "Accessories"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "Lithium-ion Battery",
                Price = 2000,
                CompanyName = "Deye",
                Description = "Lithium-ion Battery 200A , 51.2V ",
                ImageUrl = "https://toplakuca.me/wp-content/uploads/2023/01/lithium-battery-deye-se-g5.1-100ah-51.2v-1.webp",
                CategoryId = batteriesGuid
            }); 

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "Lithium-ion Battery",
                Price = 1500,
                CompanyName = "Deye",
                Description = "Lithium-ion Battery 100A , 24V ",
                ImageUrl = "https://toplakuca.me/wp-content/uploads/2023/01/lithium-battery-deye-se-g5.1-100ah-51.2v-1.webp",
                CategoryId = batteriesGuid
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Lithium-ion Battery",
                Price = 1200,
                CompanyName = "Nova",
                Description = "Lithium-ion Battery 200A , 24V ",
                ImageUrl = "https://www.nova-ess.com/wp-content/uploads/2022/08/4-1-300x159.png",
                CategoryId = batteriesGuid
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "UPS 3500W",
                Price = 1200,
                CompanyName = "Voltronic Power",
                Description = "UPS 3500W",
                ImageUrl = "https://voltronicpower.com/Content/images/product/20200214102525.jpg",
                CategoryId = invertersGuid
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "UPS 5000W",
                Price = 1200,
                CompanyName = "Voltronic Power",
                Description = "UPS 5000W",
                ImageUrl = "https://voltronicpower.com/Content/images/product/20200214102525.jpg",
                CategoryId = invertersGuid
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "Solar Panel 550W",
                Price = 1200,
                CompanyName = "SAKO",
                Description = "Solar Panel 550W",
                ImageUrl = "https://sakopower.com/wp-content/uploads/2022/05/550w%E5%A4%AA%E9%98%B3%E8%83%BD%E6%9D%BF-%E4%B8%BB%E5%9B%BE-5-2.jpg",
                CategoryId = invertersGuid
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "circuit breaker",
                Price = 1200,
                CompanyName = "CHNT",
                Description = "circuit breaker 50A Double",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSX4hjn4j-STAM068jOAFmnqUsIIrBNXhpbyUuReigg02HAPJr3pxH8KG50SuxfH3xLMKI&usqp=CAU",
                CategoryId = accessoriesGuid
            });
                    
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                OrderTotal = 245,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
                OrderTotal = 142,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                OrderTotal = 40,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
                OrderTotal = 116,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
