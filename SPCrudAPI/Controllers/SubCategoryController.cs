using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPCrudAPI.Models;
using SPCrudAPI.Repository;

namespace SPCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public SubCategoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getsubcategorylist")]
        public async Task<List<SubCategory>> GetSubCategoryListAsync()
        {
            try
            {
                return await _productService.GetSubCategoryListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getsubcategorybyid")]
        public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int Id)
        {
            try
            {
                var response = await _productService.GetSubCategoryByIdAsync(Id);

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

        [HttpPost("addsubcategory")]
        public async Task<IActionResult> AddSubCategoryAsync(SubCategory subcategory)
        {
            if (subcategory == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.A(subcategory);

                return Ok(subcategory);
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
