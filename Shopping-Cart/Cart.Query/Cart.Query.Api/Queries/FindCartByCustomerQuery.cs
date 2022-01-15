using CQRS.Core.Queries;

namespace Cart.Query.Api.Queries
{
    public class FindCartByCustomerQuery : BaseQuery
    {
        public FindCartByCustomerQuery(string username)
        {
            this.Username = username;
        }

        public string Username { get; set; }
    }
}