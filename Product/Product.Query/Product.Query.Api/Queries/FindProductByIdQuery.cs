using CQRS.Core.Queries;

namespace Product.Query.Api.Queries
{
    public class FindProductByIdQuery : BaseQuery
    {
        public FindProductByIdQuery(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}