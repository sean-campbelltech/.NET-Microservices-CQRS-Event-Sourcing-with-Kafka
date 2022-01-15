using Cart.Query.Domain.Entities;

namespace Cart.Query.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<bool> AddAsync(ShoppingCartEntity cart);
        Task<bool> UpdateAsync(int cartId, ShoppingCartEntity cart);
        Task<ShoppingCartEntity> GetAsync(int cartId);
        Task<ShoppingCartEntity> GetAsync(string username);
        Task<List<ShoppingCartEntity>> ListAsync();
        Task<List<ShoppingCartEntity>> ListAsync(int productId);
    }
}