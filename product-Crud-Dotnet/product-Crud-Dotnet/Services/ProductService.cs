using Microsoft.EntityFrameworkCore;
using product_Crud_Dotnet.Contracts;
using product_Crud_Dotnet.Models;
using product_Crud_Dotnet.Pesistence;

namespace product_Crud_Dotnet.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
            => _dbContext = dbContext;

        /// <summary>
        /// Save a new product in database
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns>Newly added product</returns>
        public async Task<Product> AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Fetch all products from database
        /// </summary>
        /// <returns>List of products</returns>
        public Task<List<Product>> GetAllProducts()
        {
            return _dbContext.Products.ToListAsync();
        }

        /// <summary>
        /// Get product details from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single product</returns>
        public async Task<Product?> GetProductById(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        /// <summary>
        /// Save product changes in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task UpdateProduct(Product product, ProductDto productDto)
        {
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.ImageUrl = productDto.ImageUrl;
            product.Price = productDto.Price;

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Remove product from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
