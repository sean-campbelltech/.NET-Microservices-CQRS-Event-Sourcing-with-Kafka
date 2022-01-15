using Cart.Query.Domain.Entities;
using Cart.Query.Domain.Repositories;

namespace Cart.Query.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Task<bool> AddAsync(ShoppingCartEntity cart)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartEntity> GetAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartEntity> GetAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartEntity>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartEntity>> ListAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int cartId, ShoppingCartEntity cart)
        {
            throw new NotImplementedException();
        }
    }
}