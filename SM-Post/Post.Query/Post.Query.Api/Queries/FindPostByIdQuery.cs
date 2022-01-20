using System.ComponentModel.DataAnnotations;
using CQRS.Core.Queries;

namespace Post.Query.Api.Queries
{
    public class FindPostByIdQuery : BaseQuery
    {
        public FindPostByIdQuery()
        {
        }

        public FindPostByIdQuery(Guid id)
        {
            this.Id = id;
        }

        [Required]
        public Guid Id { get; set; }
    }
}