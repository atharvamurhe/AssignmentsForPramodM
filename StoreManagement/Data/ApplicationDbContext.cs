using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }

    public class ProductExtraInfoDbContext : DbContext
    {
        public ProductExtraInfoDbContext(DbContextOptions<ProductExtraInfoDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductExtraInfo> ProductExtraInfos { get; set; }
    }
}
