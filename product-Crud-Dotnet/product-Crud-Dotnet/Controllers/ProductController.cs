using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using product_Crud_Dotnet.Contracts;
using product_Crud_Dotnet.Models;

namespace product_Crud_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
            => _productService = productService;

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpGet("factorial")]
        public async Task<ActionResult> GetFactorial()
        {
            var products = (await _productService.GetAllProducts())
                .Select((product, index) => new ProductFactorialDto
                {
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Row = index + 1
                });
            var productFactorials = new ConcurrentBag<ProductFactorialDto>();

            await Parallel.ForEachAsync(products, async (product, cancellationToken) =>
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var factorial = 1;

                    for (int i = 1; i <= product.Row; i++)
                    {
                        factorial = factorial * i;
                    }

                    product.Factorial = factorial;

                    productFactorials.Add(product);
                }
            });

            return Ok(productFactorials.OrderBy(product => product.Row));
        }

        /// <summary>
        /// Get single product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetSingleProduct(Guid id)
        {
            var product = await _productService.GetProductById(id);

            return product == null ? NotFound("Product Not Found") : Ok(product);
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="producDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductDto producDto)
        {
            var product = await _productService.AddProduct(producDto);

            return CreatedAtAction(nameof(GetSingleProduct), new { id = product.Id }, product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            await _productService.DeleteProduct(product);

            return NoContent();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProduct(Guid id, ProductDto productDto)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            await _productService.UpdateProduct(product, productDto);

            return NoContent();
        }
    }
}
