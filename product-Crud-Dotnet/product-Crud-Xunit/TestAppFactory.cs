using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using product_Crud_Dotnet.Models;
using product_Crud_Dotnet.Pesistence;

namespace product_Crud_Dotnet.Xunit
{
    public class TestAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ProductDbContext>));

                services.Remove(dbContextDescriptor);
                services.AddDbContext<ProductDbContext>((container, options) =>
                {
                    options.UseInMemoryDatabase("ProductsDb");
                });

                using (var dbContext = services
                    .BuildServiceProvider()
                    .GetRequiredService<ProductDbContext>())
                    {
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();

                        var products = new List<Product>()
                        {
                            new Product
                            {
                                Id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fa"),
                                Name = "product one",
                                Description = "product one description",
                                ImageUrl = "",
                                Price = 123
                            },
                            new Product
                            {
                                Id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fb"),
                                Name = "product two",
                                Description = "product two description",
                                ImageUrl = "",
                                Price = 345
                            },
                            new Product
                            {
                                Id = Guid.Parse("1faff25a-d2fd-4033-823f-57ae095793fc"),
                                Name = "product three",
                                Description = "product three description",
                                ImageUrl = "",
                                Price = 678
                            }
                        };

                        dbContext.Products.AddRange(products);
                        dbContext.SaveChanges();
                    }
            });
        }
    }
}
