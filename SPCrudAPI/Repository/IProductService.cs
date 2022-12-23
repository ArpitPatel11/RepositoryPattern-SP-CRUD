using Microsoft.AspNetCore.Mvc;
using SPCrudAPI.Models;

namespace SPCrudAPI.Repository
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<IEnumerable<Product>> GetProductByIdAsync(int Id);
        public Task<int> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);

        public Task<List<Category>> GetCategoryListAsync();
        public Task<IEnumerable<Category>> GetCategoryByIdAsync(int Id);
        public Task<int> AddCategoryAsync(Category category);
        public Task<int> UpdateCategoryAsync(Category category);
        public Task<int> DeleteCategoryAsync(int Id);


        public Task<List<SubCategory>> GetSubCategoryListAsync();
        public Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int Id);
        public Task<int> AddSubCategoryAsync(SubCategory subcategory);
        public Task<int> UpdateSubCategoryAsync(SubCategory subcategory);
        public Task<int> DeleteSubCategoryAsync(int Id);



    }
}
