using System.ComponentModel.DataAnnotations.Schema;

namespace Post.Query.Domain.Entities
{
    public class CommentEntity
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }

        [ForeignKey("PostId")]
        public PostEntity PostEntity { get; set; }
    }
}