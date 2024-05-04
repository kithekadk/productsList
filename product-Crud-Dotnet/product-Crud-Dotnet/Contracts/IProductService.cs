using product_Crud_Dotnet.Models;

namespace product_Crud_Dotnet.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Product> AddProduct(ProductDto productDto);
        Task UpdateProduct(Product product, ProductDto productDto);
        Task DeleteProduct(Product product);
    }
}
