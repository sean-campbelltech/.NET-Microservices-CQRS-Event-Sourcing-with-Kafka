using CQRS.Core.Queries;

namespace Product.Query.Api.Queries
{
    public class FindProductsByPriceQuery : BaseQuery
    {
        public FindProductsByPriceQuery(int minPrice, int maxPrice)
        {
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
        }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}