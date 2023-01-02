using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SPCrudAPI.Data;
using SPCrudAPI.Models;
using System.Data;

namespace SPCrudAPI.Repository
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dbContext;

        public ProductService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task<List<Product>> GetProductListAsync()
        {
            return await _dbContext.Products
                .FromSqlRaw<Product>("USP_Product_Get")
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByIdAsync(int ProductId)
        {
            var param = new SqlParameter("@ProductId", ProductId);

            var productDetails = await Task.Run(() => _dbContext.Products
                            .FromSqlRaw(@"exec USP_Product_GetBYId @ProductId", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", product.CategoryId));
            parameter.Add(new SqlParameter("@SubCategoryId", product.SubCategoryId));
            parameter.Add(new SqlParameter("@ProductName", product.ProductName));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));
            parameter.Add(new SqlParameter("@IsActive", product.IsActive));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec USP_Product_Insert @CategoryId,@SubCategoryId ,
                                @ProductName,  @ProductPrice, @ProductDescription, 
                               @ProductStock ,1", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId" , product.CategoryId));
            parameter.Add(new SqlParameter("@SubCategoryId", product.SubCategoryId));
            parameter.Add(new SqlParameter("@ProductId", product.ProductId));
            parameter.Add(new SqlParameter("@ProductName", product.ProductName));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));
            parameter.Add(new SqlParameter("@IsActive", product.IsActive));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec USP_Product_Update @CategoryId,@SubCategoryId,
                                @ProductId, @ProductName,@ProductPrice, 
                                @ProductDescription,  @ProductStock, 1", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteProductAsync(int ProductId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"USP_Product_Delete {ProductId}"));
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _dbContext.Categories
                .FromSqlRaw<Category>("USP_Category_Get")
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int CategoryId)
        {
            var param = new SqlParameter("@CategoryId", CategoryId);

            var categoryDetails = await Task.Run(() => _dbContext.Categories
                                .FromSqlRaw(@"exec USP_Product_GetBYId @CategoryId", param)
                                .ToListAsync());

            return categoryDetails;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@IsActive", category.IsActive));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec USP_Category_Insert @CategoryName ,1", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", category.CategoryId));
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@IsActive", category.IsActive));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec USP_Category_Update 
                                @CategoryId, @CategoryName, 1", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteCategoryAsync(int CategoryId)
        {
            return await Task.Run(() => _dbContext.Database
                    .ExecuteSqlInterpolatedAsync($"USP_Category_Delete {CategoryId}"));

        }

        public async Task<List<SubCategory>> GetSubCategoryListAsync()
        {
            return await _dbContext.SubCategories
                 .FromSqlRaw<SubCategory>("USP_SubCategory_Get")
                 .ToListAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int SubCategoryId)
        {
            var param = new SqlParameter("@SubCategoryId", SubCategoryId);

            var subcategoryDetails = await Task.Run(() => _dbContext.SubCategories
                                .FromSqlRaw(@"exec USP_SubCategory_ById @SubCategoryId", param)
                                .ToListAsync());

            return subcategoryDetails;
        }

        public async Task<int> AddSubCategoryAsync(SubCategory subcategory)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", subcategory.CategoryId));
            parameter.Add(new SqlParameter("@SubCategoryName", subcategory.SubCategoryName));
            parameter.Add(new SqlParameter("@IsActive", subcategory.IsActive));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec USP_SubCategory_Insert 
                              @CategoryId, @SubCategoryName, 1", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateSubCategoryAsync(SubCategory subcategory)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", subcategory.CategoryId));
            parameter.Add(new SqlParameter("@SubCategoryId", subcategory.SubCategoryId));
            parameter.Add(new SqlParameter("@SubCategoryName", subcategory.SubCategoryName));
            parameter.Add(new SqlParameter("@IsActive", subcategory.IsActive));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec USP_SubCategory_Update 
                                @CategoryId, @SubCategoryId, @SubCategoryName, 1",
                                parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteSubCategoryAsync(int Id)
        {
            return await Task.Run(() => _dbContext.Database
                    .ExecuteSqlInterpolatedAsync($"USP_SubCategory_Delete {Id}"));
        }
    }  
}

