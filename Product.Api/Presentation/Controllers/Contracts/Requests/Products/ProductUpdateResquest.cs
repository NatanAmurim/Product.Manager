using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.Presentation.Controllers.Contracts.Requests.Products
{
    public class ProductUpdateResquest
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
