using ProductManager.Api.Application.Commands.Product;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Interfaces;

namespace ProductManager.Api.Application
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> GetProductsAsync() => _repository.GetAllAsync();

        public async Task<Product?> GetProductAsync(string id) => await _repository.GetByIdAsync(id);

        public Task<Product> AddProductAsync(Product product) => _repository.AddAsync(product);

        public async Task UpdateProductAsync(ProductUpdateCommand productUpdateCommand) 
        {
            var product = await _repository.GetByIdAsync(productUpdateCommand.Id);

            product.Name = productUpdateCommand.Name;
            product.Price = productUpdateCommand.Price;
            product.Quantity = productUpdateCommand.Quantity;

            await _repository.UpdateAsync(product);
        } 

        public Task DeleteProductAsync(string id) => _repository.DeleteAsync(id);
    }
}
