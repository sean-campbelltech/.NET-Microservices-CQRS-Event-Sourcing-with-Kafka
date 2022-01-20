using Post.Common.DTOs;

namespace Post.Cmd.Api.DTOs
{
    public class NewPostResponse : BaseResponse
    {
        public NewPostResponse()
        {
        }

        public NewPostResponse(string message, Guid id) : base(message)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}