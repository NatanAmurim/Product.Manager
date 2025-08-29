namespace ProductManager.Api.Controllers.Contracts.Responses
{
    public class Response<T>
    {
        public Response(string message, string? code, T? content)
        {
            Message = message;
            Code = code;
            Content = content;
        }

        public string Message { get; set; }
        public string? Code { get; set; }
        public T? Content { get; set; }
    }
}
