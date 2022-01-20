using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Author { get; set; }
    }
}