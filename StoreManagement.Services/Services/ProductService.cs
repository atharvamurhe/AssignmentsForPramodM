using Microsoft.EntityFrameworkCore;
using StoreManagement.DAL.Data;
using StoreManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int? id);
        public Task<ProductExtraInfo> GetProductInfoById(int? id);
        public Task<bool> CreateProduct(Product product, ProductExtraInfo productExtraInfo);
        public Task UpdateProduct(Product product, ProductExtraInfo productExtraInfo);
        public Task DeleteProduct(int id);
        public bool ProductExist(int id);
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

        public async Task<Product> GetProductById(int? id)
        {
            using (var Context = new StoreDbContext())
            {
                return await Context.Products.FirstOrDefaultAsync(m => m.Id == id);
            }
        }
        public async Task<ProductExtraInfo> GetProductInfoById(int? id)
        {
            using (var Context = new StoreDbContext())
            {
                return await Context.ProductExtraInfos.FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task<bool> CreateProduct(Product product, ProductExtraInfo productExtraInfo)
        {
            using (var Context = new StoreDbContext())
            {
                try
                {
                    Context.Add(product);
                    Context.Add(productExtraInfo);
                    await Context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateProduct(Product product, ProductExtraInfo productExtraInfo)
        {
            using (var Context = new StoreDbContext())
            {
                Context.Update(product);
                Context.Update(productExtraInfo);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            using (var Context = new StoreDbContext())
            {
                Context.Products.Remove(product);
                await Context.SaveChangesAsync();
            }
        }

        public bool ProductExist(int id)
        {
            using (var Context = new StoreDbContext())
            {
                return Context.Products.Any(e => e.Id == id);
            }
        }
    }
}
