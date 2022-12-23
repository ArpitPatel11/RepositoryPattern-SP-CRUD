using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SPCrudAPI.Models
{
    public class SubCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
