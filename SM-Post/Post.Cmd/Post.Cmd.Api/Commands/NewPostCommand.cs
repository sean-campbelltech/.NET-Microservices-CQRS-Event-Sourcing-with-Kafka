using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class NewPostCommand : BaseCommand
    {
        public NewPostCommand(string id, string author, DateTime timeStamp, string message, int likes) : base(id)
        {
            this.Author = author;
            this.TimeStamp = timeStamp;
            this.Message = message;
            this.Likes = likes;
        }

        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public List<string>? Comments { get; set; }
    }
}