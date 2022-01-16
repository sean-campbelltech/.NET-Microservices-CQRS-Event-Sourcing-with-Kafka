using CQRS.Core.Queries;

namespace Post.Query.Api.Queries
{
    public class FindPostsWithLikesQuery : BaseQuery
    {
        public FindPostsWithLikesQuery()
        {
        }

        public FindPostsWithLikesQuery(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}