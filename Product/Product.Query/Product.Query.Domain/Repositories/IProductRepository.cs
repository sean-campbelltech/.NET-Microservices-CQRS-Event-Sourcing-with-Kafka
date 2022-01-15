using Product.Query.Domain.Entities;

namespace Product.Query.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(ProductEntity product);
        Task<ProductEntity> GetAsync(int productId);
        Task<List<ProductEntity>> ListAllAsync();
        Task<List<ProductEntity>> ListAsync(int minPrice, int maxPrice);
        Task<List<ProductEntity>> SearchAsync(string description);
    }
}