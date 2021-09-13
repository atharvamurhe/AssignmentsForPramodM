using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        //public IConfiguration Configuration; 
        //public StoreDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductExtraInfo> ProductExtraInfos { get; set; }
        public DbSet<AdvProduct> AdvProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ATHARVAM\\SQLEXPRESS;Database=StoreManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
