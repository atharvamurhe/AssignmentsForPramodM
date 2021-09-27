using Microsoft.EntityFrameworkCore;
using StoreManagement.DAL.Data;
using StoreManagement.DAL.Data.Model;
using StoreManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.Services
{
    public interface IAdvProductService
    {
        public Task<List<AdvProduct>> GetAllProducts();
        public List<vwJoinData> GetAdvProducts2();
        public Task<vwAdvProductInfo> GetProductById(int? id);
        public Task<AdvProduct> GetAdvProductById(int? id);
        public Task<bool> CreateProduct(vwAdvProductInfo vwAdvProductInfo);
        public Task UpdateProduct(AdvProduct advProduct);
        public Task DeleteProduct(AdvProduct advProduct);
        public bool ProductExist(int id);
    }
    public class AdvProductService : IAdvProductService
    {
        public async Task<bool> CreateProduct(vwAdvProductInfo vwAdvProductInfo)
        {
            using (var Context = new StoreDbContext())
            {
                try
                {
                    if (vwAdvProductInfo.Category != null)
                    {
                        Context.ProductCategories.Add(new ProductCategory
                        {
                            Id = 0,
                            Category = vwAdvProductInfo.Category
                        });
                        await Context.SaveChangesAsync();
                        var selectedCategory = await Context.ProductCategories.FirstOrDefaultAsync(o => o.Category == vwAdvProductInfo.Category);
                        vwAdvProductInfo.CategoryId = selectedCategory.Id;
                    }

                    Context.AdvProducts.Add(new AdvProduct
                    {
                        Id = vwAdvProductInfo.Id,
                        CategoryId = vwAdvProductInfo.CategoryId,
                        Name = vwAdvProductInfo.Name,
                        Quantity = vwAdvProductInfo.Quantity,
                        Price = vwAdvProductInfo.Price,
                        Cost_Price = vwAdvProductInfo.Cost_Price,
                        HSN_Code = vwAdvProductInfo.HSN_Code,
                        Is_Financeable = vwAdvProductInfo.Is_Financeable,
                        CreatedOn = vwAdvProductInfo.CreatedOn,
                        UpdatedOn = vwAdvProductInfo.UpdatedOn
                    });
                    await Context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteProduct(AdvProduct advProduct)
        {
            using(var Context = new StoreDbContext())
            {
                Context.AdvProducts.Remove(advProduct);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<AdvProduct>> GetAllProducts()
        {
            using(var Context = new StoreDbContext())
            {
                var joinContext = Context.AdvProducts.Include(a => a.ProductCategory);
                return await joinContext.ToListAsync();
            }
        }

        public List<vwJoinData> GetAdvProducts2()
        {
            using(var Context = new StoreDbContext())
            {
                try
                {
                    var joinData = from c in Context.ProductCategories
                                    join p in Context.AdvProducts
                                    on c.Id equals p.CategoryId
                                    select new vwJoinData
                                    {
                                        Name = p.Name,
                                        Category = c.Category,
                                        Quantity = p.Quantity
                                    };
                    return joinData.ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
                
                //var result = new List<object>();
                //foreach (var data in joinData)
                //{
                //    foreach(var cat in data.ProductCategory)
                //    {
                //        result.Add(new { data.name, data.quantity, cat.Category });
                //    }
                //}
                
            }
        }

        public async Task<vwAdvProductInfo> GetProductById(int? id)
        {
            using(var Context = new StoreDbContext())
            {
                var resultProduct = await Context.AdvProducts.FirstOrDefaultAsync(o => o.Id == id);
                var resultCategory = await Context.ProductCategories.FirstOrDefaultAsync(o => o.Id == resultProduct.CategoryId);
                return new vwAdvProductInfo()
                {
                    Id = resultProduct.Id,
                    CategoryId = resultProduct.CategoryId,
                    Category = resultCategory.Category,
                    Cost_Price = resultProduct.Cost_Price,
                    CreatedOn = resultProduct.CreatedOn,
                    HSN_Code = resultProduct.HSN_Code,
                    Is_Financeable = resultProduct.Is_Financeable,
                    Name = resultProduct.Name,
                    Price = resultProduct.Price,
                    Quantity = resultProduct.Quantity,
                    UpdatedOn = resultProduct.UpdatedOn
                };
            }
        }

        public async Task<AdvProduct> GetAdvProductById(int? id)
        {
            using (var Context = new StoreDbContext())
            {
                return await Context.AdvProducts.FirstOrDefaultAsync(o => o.Id == id);
            }
        }

        public bool ProductExist(int id)
        {
            using(var Context = new StoreDbContext())
            {
                return Context.AdvProducts.Any(e => e.Id == id);
            }
        }

        public async Task UpdateProduct(AdvProduct advProduct)
        {
            using(var Context = new StoreDbContext())
            {
                Context.AdvProducts.Update(advProduct);
                await Context.SaveChangesAsync();
            }
        }
    }
}
