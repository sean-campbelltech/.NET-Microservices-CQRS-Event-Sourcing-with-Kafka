namespace Post.Common.DTOs
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}