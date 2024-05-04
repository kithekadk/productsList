using System.ComponentModel.DataAnnotations;

namespace product_Crud_Dotnet.Models
{
    public class AddProduct
    {
        [Required(ErrorMessage = "Product Name is Required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product Description is Required")]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Range(1, 10000000, ErrorMessage = "Price out of Range")]
        [Required(ErrorMessage = "Product Price is Required")]
        public int Price { get; set; }
    }
}
