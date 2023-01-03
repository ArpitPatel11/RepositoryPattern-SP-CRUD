using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPCrudAPI.Models;
using SPCrudAPI.Repository;

namespace SPCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet("getproductlist")]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                return await _productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.AddProductAsync(product);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }


        }
    }
}
