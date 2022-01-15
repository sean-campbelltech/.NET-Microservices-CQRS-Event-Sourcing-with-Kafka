using Product.Query.Domain.Entities;
using Product.Query.Domain.Repositories;

namespace Product.Query.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<bool> AddAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> ListAsync(int minPrice, int maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> SearchAsync(string description)
        {
            throw new NotImplementedException();
        }
    }
}