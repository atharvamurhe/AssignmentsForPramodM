using Microsoft.AspNetCore.Mvc;
using StoreManagement.DAL.Data.Model;
using StoreManagement.Services.Services;
using StoreManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAdvProductService _advProductService;
        public ProductsController(IAdvProductService advProductService)
        {
            _advProductService = advProductService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _advProductService.GetAllProducts());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<vwAdvProductInfo> Get(int id)
        {
            return await _advProductService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async void Post([FromBody] AdvProduct advProduct)
        {
            await _advProductService.UpdateProduct(advProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] vwAdvProductInfo vwAdvProductInfo)
        {
            await _advProductService.CreateProduct(vwAdvProductInfo);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var product = await _advProductService.GetAdvProductById(id);
            await _advProductService.DeleteProduct(product);
        }
    }
}
