using CQRS.Core.Queries;

namespace Product.Query.Api.Queries
{
    public class FindProductsByDescQuery : BaseQuery
    {
        public FindProductsByDescQuery(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}