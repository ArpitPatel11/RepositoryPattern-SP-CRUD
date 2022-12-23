using Microsoft.EntityFrameworkCore;
using SPCrudAPI.Models;

namespace SPCrudAPI.Data
{
    public class DataContext :  DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Database"));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
