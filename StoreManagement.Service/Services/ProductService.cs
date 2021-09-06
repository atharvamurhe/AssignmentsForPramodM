using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.DAL.Data.Model;
using StoreManagement.DAL.Data;

namespace StoreManagement.Service.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
    }
    class ProductService : IProductService
    {
        public async Task<List<Product>> GetAllProducts()
        {
            using (var Context = new StoreDbContext())
            {
                return
            }
        }
    }
}
