using CQRS.Core.Queries;

namespace Post.Query.Api.Queries
{
    public class FindPostsByAuthorQuery : BaseQuery
    {
        public FindPostsByAuthorQuery()
        {
        }

        public FindPostsByAuthorQuery(string author)
        {
            this.Author = author;
        }

        public string Author { get; set; }
    }
}