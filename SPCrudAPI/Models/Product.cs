
namespace SPCrudAPI.Models
{
    public class Product
    {
        public int CategoryId  { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; }=string.Empty;
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }=string.Empty;
        public int ProductStock { get; set; }
        public bool? IsActive { get; set; }
    }
}
