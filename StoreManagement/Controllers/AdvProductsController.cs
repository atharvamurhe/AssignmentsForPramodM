using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagement.DAL.Data;
using StoreManagement.DAL.Data.Model;
using StoreManagement.Services.Services;
using StoreManagement.Services.ViewModel;

namespace StoreManagement.Controllers
{
    public class AdvProductsController : Controller
    {
        private readonly StoreDbContext _context;
        private readonly IAdvProductService _advProductService;

        public AdvProductsController(StoreDbContext context, IAdvProductService advProductService)
        {
            _context = context;
            _advProductService = advProductService;
        }

        // GET: AdvProducts
        public async Task<IActionResult> Index(string searchQuery)
        {
            var products = new List<AdvProduct>();
            if (searchQuery == null)
            {
                products = await _advProductService.GetAllProducts();
            }
            else
            {
                ViewData["searchQuery"] = searchQuery;
                var result = await _advProductService.GetAllProducts();
                products = result.Where(a => a.Name.ToLower().Contains(searchQuery) || a.ProductCategory.Category.ToLower().Contains(searchQuery)).ToList();
            }
            
            return View(products.OrderBy(o => o.ProductCategory.Category));
        }

        //Multiple Route using attribute routing
        [Route("AdvProducts/Details")]
        [Route("Details")]
        // GET: AdvProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advProductInfo = await _advProductService.GetProductById(id);
            if (advProductInfo == null)
            {
                return NotFound();
            }

            return View(advProductInfo);
        }

        // GET: AdvProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "Id", "Category");
            return View();
        }

        // POST: AdvProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Category,Quantity,Price,Cost_Price,HSN_Code,Is_Financeable,CreatedOn,UpdatedOn")] vwAdvProductInfo vwAdvProductInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _advProductService.CreateProduct(vwAdvProductInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "Id", "Category", vwAdvProductInfo.CategoryId);
            return View(vwAdvProductInfo);
        }

        // GET: AdvProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advProductInfo = await _advProductService.GetProductById(id);
            if (advProductInfo == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "Id", "Category", advProductInfo.CategoryId);
            return View(advProductInfo);
        }

        // POST: AdvProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Quantity,Price,Cost_Price,HSN_Code,Is_Financeable,CreatedOn,UpdatedOn")] AdvProduct advProduct)
        {
            if (id != advProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _advProductService.UpdateProduct(advProduct);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvProductExists(advProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "Id", "Category", advProduct.CategoryId);
            return View(advProduct);
        }

        // GET: AdvProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _advProductService.GetProductById(id);
            var advProduct = new AdvProduct()
            {
                Id = result.Id,
                CategoryId = result.CategoryId,
                Cost_Price = result.Cost_Price,
                CreatedOn = result.CreatedOn,
                HSN_Code = result.HSN_Code,
                Is_Financeable = result.Is_Financeable,
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity,
                UpdatedOn = result.UpdatedOn
            };

            if (advProduct == null)
            {
                return NotFound();
            }

            return View(advProduct);
        }

        // POST: AdvProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _advProductService.GetProductById(id);
            var advProduct = new AdvProduct()
            {
                Id = result.Id,
                CategoryId = result.CategoryId,
                Cost_Price = result.Cost_Price,
                CreatedOn = result.CreatedOn,
                HSN_Code = result.HSN_Code,
                Is_Financeable = result.Is_Financeable,
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity,
                UpdatedOn = result.UpdatedOn
            };

            await _advProductService.DeleteProduct(advProduct);
            return RedirectToAction(nameof(Index));
        }

        private bool AdvProductExists(int id)
        {
            return _advProductService.ProductExist(id);
        }
    }
}
