using CQRS.Core.Queries;

namespace Post.Query.Api.Queries
{
    public class FindPostByIdQuery : BaseQuery
    {
        public FindPostByIdQuery()
        {
        }

        public FindPostByIdQuery(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}