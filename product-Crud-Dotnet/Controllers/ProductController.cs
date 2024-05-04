using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using product_Crud_Dotnet.Models;

namespace product_Crud_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new() 
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "Lenovo",
                Price= 1000
            }
        };

        //Get all

        [HttpGet("all")]
        public ActionResult getProducts()
        {
            return Ok(products);
        }

        //GET ONE
        [HttpGet("{id:guid}")]
        public ActionResult getaProducts(Guid id)
        {
            var product = products.Find(product => product.Id == id);
            if(product == null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        //ADD NEW PRODUCT

        [HttpPost]
        public ActionResult addProduct(AddProduct newProduct)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price
            };

            products.Add(product);
            return Created($"https://localhost:7069/api/Product/{product.Id}", "Product created successfully");
        }

        //DELETE PRODUCT

        [HttpDelete("{id:guid}")]
        public ActionResult deleteProduct(Guid id)
        {
            var product = products.Find(product => product.Id == id);

            if(product == null)
            {
                return NotFound("Product Not Found");
            }

            products.Remove(product);

            return NoContent();
        }

        //UPDATE PRODUCT
        [HttpPut("{id:guid}")]

        public ActionResult updateProduct(Guid id, AddProduct Updatedproduct)
        {
            var product = products.Find(product => product.Id == id);

            if(product == null)
            {
                return NotFound("Product Not Found");
            }

            product.Price = Updatedproduct.Price;
            product.Name = Updatedproduct.Name;
            product.Description = Updatedproduct.Description;

            return NoContent();
        }
    }
}
