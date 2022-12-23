using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPCrudAPI.Models;
using SPCrudAPI.Repository;

namespace SPCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getcategorylist")]
        public async Task<List<Category>> GetCategoryListAsync()
        {
            try
            {
                return await _productService.GetCategoryListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getcategorybyid")]
        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int Id)
        {
            try
            {
                var response = await _productService.GetCategoryByIdAsync(Id);

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

        [HttpPost("addcategory")]
        public async Task<IActionResult> AddCategoryAsync(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.AddCategoryAsync(category);

                return Ok(category);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatecategory")]
        public async Task<IActionResult> UpdateCategoryAsync(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _productService.UpdateCategoryAsync(category);
                return Ok(category);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletecategory")]
        public async Task<int> DeleteCategoryAsync(int Id)
        {
            try
            {
                var response = await _productService.DeleteCategoryAsync(Id);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


        }


    }
}
