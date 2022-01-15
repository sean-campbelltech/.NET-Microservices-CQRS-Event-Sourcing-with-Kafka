using CQRS.Core.Queries;

namespace Cart.Query.Api.Queries
{
    public class FindCartByIdQuery : BaseQuery
    {
        public FindCartByIdQuery(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}