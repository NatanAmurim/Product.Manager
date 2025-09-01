using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.Controllers.Contracts.Requests.Products
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
