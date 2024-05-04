using System.Text;
using System.Net;
using Newtonsoft.Json;
using product_Crud_Dotnet.Models;

namespace product_Crud_Dotnet.Xunit
{
    public class ProductControllerTests : IClassFixture<TestAppFactory<Program>>
    {
        private readonly TestAppFactory<Program> _factory;

        public ProductControllerTests(TestAppFactory<Program> factory)
            => _factory = factory ?? throw new ArgumentNullException($"{nameof(TestAppFactory<Program>)} dependency is missing");

        [Fact]
        public async Task Should_Get_All_Products()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/Product/all");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<List<Product>>(json);
            var result = Assert.IsType<List<Product>>(body);

            Assert.Equal(3, result.Count);
        }
        
        [Fact]
        public async Task Should_Create_Product()
        {
            var newProduct = new ProductDto
            {
                Name = "new prod",
                Description = "prod desc",
                Price = 123,
                ImageUrl = "www.image.com"
            };
            var client = _factory.CreateClient();
            var payload = JsonConvert.SerializeObject(newProduct);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Product", content);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<Product>(json);
            var result = Assert.IsType<Product>(body);

            Assert.Equal(newProduct.Name, result.Name);
        }

        [Fact]
        public async Task Should_Get_Product_Details()
        {
            var id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fa");
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"/api/Product/{id}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<Product>(json);
            var result = Assert.IsType<Product>(body);

            Assert.Equal(id, result.Id);
        }
        
        [Fact]
        public async Task Should_Update_Product()
        {
            var id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fa");
            var editProduct = new Product
            {
                Name = "update product",
                Description = "update product",
                ImageUrl = "",
                Price = 123
            };
            var client = _factory.CreateClient();
            var payload = JsonConvert.SerializeObject(editProduct);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/Product/{id}", content);

            response.EnsureSuccessStatusCode();
            
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
        [Fact]
        public async Task Should_Delete_Product()
        {
            var id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fb");
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"/api/Product/{id}");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
