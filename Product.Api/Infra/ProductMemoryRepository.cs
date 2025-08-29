using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Interfaces;

namespace ProductManager.Api.Infra
{
    public class ProductMemoryRepository : IProductRepository
    {
        public Task<Product> AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
