using Microsoft.EntityFrameworkCore;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Interfaces;
using ProductManager.Api.Infra.Persistence;

namespace ProductManager.Api.Infra.Repositories
{
    public class ProductMemoryRepository(AppDbContext appDbContext) : IProductRepository
    {
        public async Task<Product> AddAsync(Product product)
        {
            appDbContext.Add(product);
            await appDbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(string id)
        {
            var productInDataBase = await appDbContext.Products.FindAsync(id);
            if (productInDataBase is not null)
            {
                appDbContext.Products.Remove(productInDataBase);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            return await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);    
        }

        public async Task UpdateAsync(Product product)
        {
            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();
        }
    }
}
