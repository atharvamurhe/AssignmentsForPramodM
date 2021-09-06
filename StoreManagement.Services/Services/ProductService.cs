using Microsoft.EntityFrameworkCore;
using StoreManagement.DAL.Data;
using StoreManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
    }
    public class ProductService : IProductService
    {
        public async Task<List<Product>> GetAllProducts()
        {
            using (var Context = new StoreDbContext())
            {
                return await Context.Products.ToListAsync();
            }
        }
    }
}
