using System.ComponentModel.DataAnnotations;
using CQRS.Core.Queries;

namespace Post.Query.Api.Queries
{
    public class FindPostsWithLikesQuery : BaseQuery
    {
        public int Quantity { get; set; }
    }
}