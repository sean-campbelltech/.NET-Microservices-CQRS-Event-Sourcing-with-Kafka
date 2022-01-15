using CQRS.Core.Queries;

namespace Cart.Query.Api.Queries
{
    public class FindCartsWithProductQuery : BaseQuery
    {
        public FindCartsWithProductQuery(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}