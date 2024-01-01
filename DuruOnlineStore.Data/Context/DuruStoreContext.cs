using DuruOnlineStore.Data.Base;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.Data.Entities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Context
{
    public partial class DuruStoreContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DuruStoreContext(DbContextOptions<DuruStoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DuruOnlineStoreDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(6,2);

            SeedCategories(modelBuilder);
            SeedProducts(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            int Admin_Role_Id = 10;
            int User_Role_Id = 20;
            int Admin_User_Id = 1;

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = Admin_Role_Id,
                ConcurrencyStamp = Admin_Role_Id.ToString(),
            });

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = User_Role_Id,
                ConcurrencyStamp = User_Role_Id.ToString()
            });
        }
    }
}
