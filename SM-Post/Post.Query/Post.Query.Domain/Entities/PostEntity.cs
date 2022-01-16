using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Post.Query.Domain.Entities
{
    [Table("Post")]
    public class PostEntity
    {
        [Key]
        public string PostId { get; set; }
        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public ICollection<CommentEntity>? Comments { get; set; }
    }
}