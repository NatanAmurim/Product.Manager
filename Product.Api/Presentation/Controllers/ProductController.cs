using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.Application;
using ProductManager.Api.Application.Commands.Product;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Presentation.Controllers.Contracts.Requests.Products;
using ProductManager.Api.Presentation.Controllers.Contracts.Responses;
using ProductManager.Api.Presentation.Extensions;

namespace ProductManager.Api.Presentation.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest productResquest)
        {
            var product = new Product(productResquest.Name.Sanitize(), productResquest.Price, productResquest.Quantity);

            var productCreateResult = await _productService.AddProductAsync(product);

            return CreatedAtAction(nameof(CreateProduct), new Response<Product>("Product Created with Success!", "", productCreateResult));
        }

        [HttpGet("get-all-products")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllProducts()
        {
            var getProductsResult = await _productService.GetProductsAsync();

            return CreatedAtAction(nameof(GetAllProducts), new Response<IEnumerable<Product>>("List of all products.", "", getProductsResult));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var getProductsResult = await _productService.GetProductAsync(id);

            return CreatedAtAction(nameof(GetProduct), new Response<Product>("Product found.", "", getProductsResult));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateResquest productUpdateResquest)
        {
            var productUpdateCommand = new ProductUpdateCommand(productUpdateResquest.Id, productUpdateResquest.Name.Sanitize(), productUpdateResquest.Price, productUpdateResquest.Quantity);

            await _productService.UpdateProductAsync(productUpdateCommand);

            return CreatedAtAction(nameof(GetProduct), new Response<Product>("Product updated.", "", default));
        }

        [HttpDelete]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);

            return CreatedAtAction(nameof(GetProduct), new Response<Product>("Product deleted.", "", default));
        }
    }
}
