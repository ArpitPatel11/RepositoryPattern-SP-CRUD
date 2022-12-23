namespace SPCrudAPI.Models
{
    public class SubCategory
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }    = string.Empty;
        public bool? IsActive { get; set; }
    }
}
