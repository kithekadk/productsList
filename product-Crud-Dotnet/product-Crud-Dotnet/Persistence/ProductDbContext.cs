using Microsoft.EntityFrameworkCore;
using product_Crud_Dotnet.Models;

namespace product_Crud_Dotnet.Pesistence
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public ProductDbContext(DbContextOptions options) : base(options) { }
    }
}
