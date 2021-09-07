using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.DAL.Data;
using StoreManagement.DAL.Data.Model;
using StoreManagement.Services.Services;
using StoreManagement.ViewModel;

namespace StoreManagement.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly StoreDbContext _context;
        private readonly IProductService _productService;
        public ProductsController(StoreDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewBag.ProductCount = _context.Products.Count(); //Passed data from controller to view using ViewBag
            return View(await _productService.GetAllProducts());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _context.Products
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //var productExtraInfo = await _context.ProductExtraInfos
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var product = await _productService.GetProductById(id);
            var productExtraInfo = await _productService.GetProductInfoById(id);

            ViewData["ProductId"] = id;   //Used ViewData to pass data from controller to view

            if (product == null || productExtraInfo == null)
            {
                return NotFound();
            }

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            productDetailViewModel.Product = product;
            productDetailViewModel.ProductExtraInfo = productExtraInfo;

            return View(productDetailViewModel);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_Name,Product_Category,Product_Quantity,Product_Price")] Product product,
            [Bind("Id,Product_Cost_Price,HSN_Code,IsFinanceable")] ProductExtraInfo productExtraInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _productService.CreateProduct(product, productExtraInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            productDetailViewModel.Product = product;
            productDetailViewModel.ProductExtraInfo = productExtraInfo;
            return View(productDetailViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(id);
            var productExtraInfo = await _productService.GetProductInfoById(id);
            if (product == null || productExtraInfo == null)
            {
                return NotFound();
            }

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            productDetailViewModel.Product = product;
            productDetailViewModel.ProductExtraInfo = productExtraInfo;

            return View(productDetailViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product_Name,Product_Category,Product_Quantity,Product_Price")] Product product,
            [Bind("Id,Product_Cost_Price,HSN_Code,IsFinanceable")] ProductExtraInfo productExtraInfo)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(product);
                    //_context.Update(productExtraInfo);
                    //await _context.SaveChangesAsync();
                    await _productService.UpdateProduct(product, productExtraInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            productDetailViewModel.Product = product;
            productDetailViewModel.ProductExtraInfo = productExtraInfo;
            return View(productDetailViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var product = await _context.Products.FindAsync(id);
            //_context.Products.Remove(product);
            //await _context.SaveChangesAsync();
            await _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            //return _context.Products.Any(e => e.Id == id);
            return _productService.ProductExist(id);
        }
    }
}
